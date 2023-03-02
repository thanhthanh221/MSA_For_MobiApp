using Application.Common.Repository;
using CatchingRedis.Data;
using CatchingRedis.Services;
using Market.Product.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Market.Product.Domain.Queries.FindProductByCategory;

public class ProductByCategoryHandler : IRequestHandler<ProductByCategoryQuery, List<ProductAggregate>>
{
    private readonly IRepository<ProductAggregate> productRepository;
    private readonly ILogger<ProductByCategoryHandler> logger;
    private readonly IReposeCacheService cacheService;

    public ProductByCategoryHandler(
        IRepository<ProductAggregate> productRepository, ILogger<ProductByCategoryHandler> logger, IReposeCacheService cacheService)
    {
        this.productRepository = productRepository;
        this.logger = logger;
        this.cacheService = cacheService;
    }

    public async Task<List<ProductAggregate>> Handle(ProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        var productInCatche = await cacheService.GetAllCacheReponseAsync(RedisCachePattern.ProductPattern);
        if (productInCatche.Count != 0) {
            // Product In Cache
            List<ProductAggregate> products = productInCatche.Select(pro => {
                return JsonConvert.DeserializeObject<ProductAggregate>(pro);
            }).ToList();

            //Filter In Cache
            List<ProductAggregate> productCategoryInCache = products.Where(pro => pro.Categories
                                    .Any(c => c.CategoryId.Equals(request.CategoryId))).ToList();

            if (productCategoryInCache != null) { return productCategoryInCache; }

        }
        // Filter Product In Db 
        var productFindByCategoryInDb = await productRepository.GetsAsync(p =>
                                        p.Categories.Any(c => c.CategoryId.Equals(request.CategoryId)));

        if (productFindByCategoryInDb is null) { return null; }

        //Update Cache
        productFindByCategoryInDb.ForEach(async p => {
            logger.LogInformation("Cập nhật thêm Product vào Cache {ProductId}-{ProductName}", p.Id, p.Name);
            await cacheService.SetCacheReponseAsync(RedisCachePattern.ProductPattern + p.Id, p, new TimeSpan(10, 10, 10));
        });
        return productFindByCategoryInDb;
    }
}

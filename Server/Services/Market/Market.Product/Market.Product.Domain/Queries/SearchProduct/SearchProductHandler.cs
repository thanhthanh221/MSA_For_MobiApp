using Application.Common.Data;
using Application.Common.Repository;
using CatchingRedis.Services;
using Market.Product.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Market.Product.Domain.Queries.SearchProduct;

public class SearchProductHandler : IRequestHandler<SearchProductQuery, List<ProductAggregate>>
{
    private readonly IRepository<ProductAggregate> productRepository;
    private readonly ILogger<SearchProductHandler> logger;
    private readonly IReposeCacheService cacheService;

    public SearchProductHandler(IRepository<ProductAggregate> productRepository, ILogger<SearchProductHandler> logger, IReposeCacheService cacheService)
    {
        this.productRepository = productRepository;
        this.logger = logger;
        this.cacheService = cacheService;
    }

    public async Task<List<ProductAggregate>> Handle(SearchProductQuery filter, CancellationToken cancellationToken)
    {
        if (filter.MinDistance > filter.MaxDistance || filter.MaxPrice < filter.MinPrice) { return null; }
        List<ProductAggregate> products= new();
        // Lấy sản phẩm ở cache
        var productInCatche = await cacheService.GetAllCacheReponseAsync(RedisCachePattern.ProductPattern);
        if (productInCatche != null) {
            products = productInCatche.Select(pro => {
                return JsonConvert.DeserializeObject<ProductAggregate>(pro);
            }).ToList();
        }

        if (products is null) {
            products = (await productRepository.GetAllAsync()).ToList();
            //Update Cache
            if (products is null) { return null; }
        }
        // Filter Product Linq
        var productSearch = from pro in products
                            where filter.MinStar > pro.Star
                                && !(pro.Price >= filter.MinPrice && pro.Price <= filter.MaxPrice)
                                && filter.MinTimeOrder <= pro.TimeOrder.TotalMinutes
                                && (filter.CategoryId == null || pro.Categories.Any(c => c.CategoryId.Equals(filter.CategoryId)))
                            orderby pro.Name
                            select pro;
        if (productInCatche is null) {
            productSearch.ToList().ForEach(async pro => {
                //Update lại toàn bộ cache
                logger.LogInformation("Thêm 1 sản phẩm vào cache {ProductId} - {ProductName}", pro.Id, pro.Name);
                await cacheService.SetCacheReponseAsync($"{RedisCachePattern.ProductPattern}+{pro.Id}", pro, new TimeSpan());
            });
        }
        return productSearch.ToList();
    }
}

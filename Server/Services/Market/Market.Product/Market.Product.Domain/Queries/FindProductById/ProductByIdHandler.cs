using Application.Common.Data;
using Application.Common.Repository;
using CatchingRedis.Services;
using Market.Product.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Market.Product.Domain.Queries.FindProductById
{
    public class ProductByIdHandler : IRequestHandler<ProductByIdQuery, ProductAggregate>
    {
        private readonly IRepository<ProductAggregate> productRepository;
        private readonly ILogger<ProductByIdHandler> logger;
        private readonly IReposeCacheService cacheService;

        public ProductByIdHandler(
            IRepository<ProductAggregate> productRepository, ILogger<ProductByIdHandler> logger, IReposeCacheService cacheService)
        {
            this.productRepository = productRepository;
            this.logger = logger;
            this.cacheService = cacheService;
        }

        public async Task<ProductAggregate> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        {
            _ = new ProductAggregate();
            // Read Cache
            string productInCatche = await cacheService.GetCacheReponseAsync(RedisCachePattern.ProductPattern + request.ProductId);
            ProductAggregate product;
            if (productInCatche != null) {
                product = JsonConvert.DeserializeObject<ProductAggregate>(productInCatche);
                return product;
            }

            product = await productRepository.GetByIdAsync(request.ProductId);
            if (product is null) { return null; }

            // Update Cache
            await cacheService.SetCacheReponseAsync($"GetProduct_{request.ProductId}", product, new TimeSpan(10,0,0));
            logger.LogInformation("Thêm 1 sản phẩm vào cache {ProductId} - {ProductName}", request.ProductId, product.Name);

            return product;
        }
    }
}
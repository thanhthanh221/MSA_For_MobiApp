using CatchingRedis.Services;
using Market.Domain.Events.CreateProduct;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Newtonsoft.Json;

namespace Market.Domain.Queries.ProductById
{
    public class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, Product>
    {
        private readonly IAsyncRepository<Product> productRepository;
        private readonly IReposeCacheService reposeCache;
        private readonly IMediator mediator;

        public ProductByIdQueryHandler(
            IAsyncRepository<Product> productRepository, IReposeCacheService reposeCache, IMediator mediator)
        {
            this.productRepository = productRepository;
            this.reposeCache = reposeCache;
            this.mediator = mediator;
        }

        public async Task<Product> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        {
            string productInCatche = await reposeCache.GetCacheReponseAsync("GetProduct_" + request.ProductId);

            if(productInCatche != null)
            {
                var product = JsonConvert.DeserializeObject<Product>(productInCatche);

                return product;
            }
            var productInDb = await productRepository.GetByIdAsync(request.ProductId);

            if(productInDb is null)
            {
                return null;
            }

            // Trong trường Hợp Db Có thì Update lại Catche

            CreateProductEvent createProductEvent = new(productInDb);

            // Tạo mới Catche
            await mediator.Publish(createProductEvent, cancellationToken);

            return productInDb;
        }
    }
}
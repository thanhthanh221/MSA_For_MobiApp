using System.Text.Json;
using CatchingRedis.Services;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;

namespace Market.Domain.Queries.ProductByCategory
{
    public class ProductByCategoryQueryHandler 
        : IRequestHandler<ProductByCategoryQuery, List<Product>>
    {
        private readonly IReposeCacheService reposeCache;
        private readonly IAsyncRepository<Product> productRepository;

        public ProductByCategoryQueryHandler(
            IReposeCacheService reposeCache, IAsyncRepository<Product> productRepository)
        {
            this.reposeCache = reposeCache;
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(ProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var productString = await reposeCache
                . GetAllCacheReponseAsync(request.Pattern);
            
            List<Product> products = new ();
            foreach (var proString in productString)
            {
                var pro = JsonSerializer.Deserialize<Product>(proString);

                if(pro.Categories.Any(p => p.Id == request.CategoryId))
                {
                    products.Add(pro);
                }
            }

            if(products is null || products.Count < 10)
            {
                List<Product> productAllInDb  = (await productRepository.GetAllAsync()).ToList();

                var productConstainCategoryId = from p in productAllInDb
                                  where p.Categories.Any(c => c.Id == request.CategoryId)
                                  select p;

                List<Product> productPage =  productConstainCategoryId
                                    .Skip(request.Page* request.PageSize)
                                    .Take(request.PageSize)
                                    .ToList();

                if(productPage is null)
                {
                    return null;
                }

                return productPage.Count > 0 ? productPage : null;   
            }
            return products;
        }
    }
}
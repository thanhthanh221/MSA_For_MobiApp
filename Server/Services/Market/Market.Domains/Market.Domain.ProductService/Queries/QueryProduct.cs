using Application.Common.Repository;
using CatchingRedis.Services;
using Market.Domain.ProductService.Extensions;
using Market.Domain.ProductService.Model;
using Newtonsoft.Json;

namespace Market.Domain.ProductService.Queries
{
    public class QueryProduct : IQueryProduct
    {
        private readonly IRepository<ProductAggregate> productRepository;
        private readonly IReposeCacheService reposeCache;

        public QueryProduct(
            IRepository<ProductAggregate> productRepository, IReposeCacheService reposeCache)
        {
            this.productRepository = productRepository;
            this.reposeCache = reposeCache;
        }

        public async Task<List<ProductAggregate>> FilterByCategory(Guid CategoryId)
        {
            var productInCatche = await reposeCache.GetAllCacheReponseAsync("GetProduct_");
            List<ProductAggregate> products = productInCatche.Select(pro => {
                return JsonConvert.DeserializeObject<ProductAggregate>(pro);
            }).ToList();

            if(products != null) {
                return products.Where(pro => pro.Categories.Any(c => c.CategoryId.Equals(CategoryId))).ToList();
            }
            
            products = (await productRepository.GetAllAsync())
                        .Where(pro => pro.Categories.Any(c => c.CategoryId.Equals(CategoryId))).ToList();

            return products;
        }

        public async Task<ProductAggregate> FilterById(Guid ProductId)
        {
            string productInCatche = await reposeCache.GetCacheReponseAsync("GetProduct_" + ProductId);
            var product = JsonConvert.DeserializeObject<ProductAggregate>(productInCatche);

            if (product != null) { return product; }
            product = await productRepository.GetByIdAsync(ProductId);
            if (product is null) { return null; }

            // Update Cache
            await reposeCache.SetCacheReponseAsync($"GetProduct_{ProductId}", product, new TimeSpan());

            return product;
        }

        public async Task<List<ProductAggregate>> FilterByRequestQuery(FilterRequest filter)
        {
            if (filter.MinDistance > filter.MaxDistance || filter.MaxPrice < filter.MinPrice) { return null; }

            var productInCatche = await reposeCache.GetAllCacheReponseAsync("GetProduct_");
            List<ProductAggregate> products = productInCatche.Select(pro => {
                return JsonConvert.DeserializeObject<ProductAggregate>(pro);
            }).ToList();

            if (products is null) {
                products = (await productRepository.GetAllAsync()).ToList();
                if (products is null) { return null; }
            }

            var productReturn = from pro in products
                                where filter.MinStar > pro.Star
                                    && !(pro.Price >= filter.MinPrice && pro.Price <= filter.MaxPrice)
                                    && filter.MinTimeOrder <= pro.TimeOrder.TotalMinutes
                                    && (filter.CategoryId == null || pro.Categories.Any(c => c.CategoryId.Equals(filter.CategoryId)))
                                orderby pro.Name
                                select pro;

            //Update Catche
            productReturn.ToList().ForEach(async pro => {
                await reposeCache.SetCacheReponseAsync($"GetProduct_{pro.Id}", pro, new TimeSpan());
            });

            return productReturn.ToList();
        }
    }
}
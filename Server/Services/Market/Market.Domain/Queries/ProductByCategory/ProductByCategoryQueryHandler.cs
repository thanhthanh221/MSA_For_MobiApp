using System.Text;
using CatchingRedis.Services;
using Market.Domain.Events.CreateProduct;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Newtonsoft.Json;

namespace Market.Domain.Queries.ProductByCategory
{
    public class ProductByCategoryQueryHandler
        : IRequestHandler<ProductByCategoryQuery, List<Product>>
    {
        private readonly IReposeCacheService reposeCache;
        private readonly IAsyncRepository<Product> productRepository;
        private readonly IMediator mediator;

        public ProductByCategoryQueryHandler(
            IReposeCacheService reposeCache, IAsyncRepository<Product> productRepository, IMediator mediator)
        {
            this.reposeCache = reposeCache;
            this.productRepository = productRepository;
            this.mediator = mediator;
        }

        public async Task<List<Product>> Handle(ProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var fullProductInCatche = await reposeCache.GetAllCacheReponseAsync(request.Pattern);

            List<Product> products = new();

            if (fullProductInCatche != null) {
                foreach (var pro in fullProductInCatche) {

                    var product = JsonConvert.DeserializeObject<Product>(pro);

                    var checkCategoryProduct = product.Categories.Any(c => c.Id.Equals(request.CategoryId));

                    if (checkCategoryProduct) {
                        products.Add(product);
                    }
                }
            }

            // Nếu Trong Catche(Redis) không có sản phẩm thì check trong Db
            if (products.Count == 0) {
                List<Product> productAllInDb = (await productRepository.GetAllAsync()).ToList();

                // Trường hợp trong Db không có sản phẩm
                if(productAllInDb is null)
                {
                    return null;
                }
                
                var productConstainCategoryId = from p in productAllInDb
                                                where p.Categories.Any(c => c.Id == request.CategoryId)
                                                select p;

                products.AddRange(productConstainCategoryId);

                // Update Lại Catche
                foreach (var pro in productConstainCategoryId)
                {
                    
                    CreateProductEvent createProductEvent = new(pro);

                    // Gửi cho Event xử lý
                    await mediator.Publish(createProductEvent, cancellationToken);
                }

                if (products.Count == 0) {
                    // Nếu trong Db không có sản phẩm nữa thì return về Null
                    return null;
                }
            }

            // Phân trang cho sản phẩm
            List<Product> productPage = products
                                        .Skip(request.Page * request.PageSize)
                                        .Take(request.PageSize)
                                        .ToList();
            return productPage;
        }
    }
}
using CatchingRedis.Services;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Newtonsoft.Json;

namespace Market.Domain.Queries.FilterProduct
{
    public class FilterProductQueryHandler : IRequestHandler<FilterProductQuery, List<Product>>
    {
        private readonly IReposeCacheService reposeCache;
        private readonly IAsyncRepository<Product> productRepository;

        public FilterProductQueryHandler(
            IReposeCacheService reposeCache, IAsyncRepository<Product> productRepository)
        {
            this.reposeCache = reposeCache;
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(FilterProductQuery request, CancellationToken cancellationToken)
        {
            if (request.MinDistance > request.MaxDistance || request.MaxPrice < request.MinPrice) {
                return null;
            }
            var productInCatche = await reposeCache.GetAllCacheReponseAsync("GetProduct_");

            List<Product> products = new();

            if (productInCatche != null) {

                // Đọc trong Catche
                foreach (var pro in productInCatche) {
                    var product = JsonConvert.DeserializeObject<Product>(pro);

                    // Thỏa mãn các check thì thêm sản phẩm vào trong danh sách
                    products.Add(product);
                }

                // Nếu trong Catche không có dữ liệu thì đọc trong Db
                if (products.Count == 0) {
                    List<Product> productInDb = (await productRepository.GetAllAsync()).ToList();

                    if (productInDb is null) {
                        return null;
                    }
                    products.AddRange(productInDb);
                }

                foreach (var pro in products) {
                    // check giá sản phẩm
                    if (!(pro.Price >= request.MinPrice && pro.Price <= request.MaxPrice)) {
                        products.Remove(pro);
                        continue;
                    }

                    // Check Đánh giá sản phẩm
                    if (request.MinStar > pro.Star) {
                        products.Remove(pro);
                        continue;
                    }

                    // Check danh mục sản phẩm
                    if (request.CategoryId != null) {
                        var checkCategory = pro.Categories.Any(c => c.Id.Equals(request.CategoryId));

                        // Nếu Sản phẩm không nằm trong danh mục =)))
                        if (!checkCategory) {
                            products.Remove(pro);
                            continue;
                        }
                    }
                    if (request.MinTimeOrder <= pro.TimeOrder.TotalMinutes) {
                        products.Remove(pro);
                        continue;
                    }
                }
            }
            return products.Skip(request.Page * 5).Take(5).ToList();
        }
    }
}
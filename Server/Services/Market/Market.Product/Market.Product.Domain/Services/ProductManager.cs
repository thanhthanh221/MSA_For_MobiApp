using Application.Common.Helper;
using Application.Common.Repository;
using Market.Product.Domain.Commands.CreateProduct;
using Market.Product.Domain.Interfaces;
using Market.Product.Domain.Model;
using Newtonsoft.Json;

namespace Market.Product.Domain.Services
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<ProductAggregate> productRepository;

        public ProductManager(IRepository<ProductAggregate> productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<bool> CheckFavouriteProductAsync(ProductAggregate product, Guid userId)
        {
            return Task.FromResult(product.UserLikeProduct.Any(uId => uId.Equals(userId)));
        }

        public async Task<ProductAggregate> CreateAsync(CreateProductCommand createProduct)
        {
            var allProduct = await productRepository.GetAllAsync();
            var checkProduct = allProduct
                        .Any(p => p.Name.ToLower()
                        .Equals(createProduct.Name.Trim().ToLower()));
            if (checkProduct) { return null; }

            string imageToString = await UploadFileHelper.SaveImage(createProduct.Image, null);
            var productTypes = JsonConvert.DeserializeObject<List<ProductType>>(createProduct.ProductTypes);
            TimeSpan timeOrder = new(createProduct.TimeOrder.Day, createProduct.TimeOrder.Hours, createProduct.TimeOrder.Minute, 0);
            var categories = JsonConvert.DeserializeObject<List<ProductCategory>>(createProduct.Categories);

            ProductAggregate product = new(
                createProduct.Name,
                createProduct.Calo,
                createProduct.Descretion,
                createProduct.TypeNameProduct,
                productTypes,
                categories,
                imageToString,
                timeOrder
            );
            await productRepository.CreateAsync(product);
            return product;
        }
    }
}
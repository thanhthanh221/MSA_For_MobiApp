using Application.Common.Helper;
using Application.Common.Repository;
using Market.Domain.ProductService.Commands.CreateProduct;
using Market.Domain.ProductService.Model;
using Newtonsoft.Json;

namespace Market.Domain.ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<ProductAggregate> productRepository;

        public ProductService(IRepository<ProductAggregate> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ProductAggregate> AddProduct(CreateProductCommand createProductCommand)
        {
            var allProduct = await productRepository.GetAllAsync();
            var checkProduct = allProduct
                        .Any(p => p.Name.ToLower()
                        .Equals(createProductCommand.Name.Trim().ToLower()));

            if (checkProduct) { return null; }

            string imageToString = UploadFileHelper.IFormFileToBase64ImageOfVideo(createProductCommand.Image);

            var productTypes = JsonConvert.DeserializeObject<List<ProductType>>(createProductCommand.TypeProducts);

            ProductAggregate product = new(
                createProductCommand.Name.Trim(),
                createProductCommand.Calo,
                createProductCommand.Descretion.Trim(),
                createProductCommand.TypeName.Trim(),
                productTypes.ToHashSet(),
                createProductCommand.UserId,
                createProductCommand.UserName.Trim(),
                imageToString,
                new TimeSpan(createProductCommand.TimeOrder.Day, createProductCommand.TimeOrder.Hours, createProductCommand.TimeOrder.Minute, 0)
            );
            
            return product;

        }

        public Task<bool> CheckCategoryProduct(List<ProductCategory> productCategories)
        {
            throw new NotImplementedException();
        }
    }
}
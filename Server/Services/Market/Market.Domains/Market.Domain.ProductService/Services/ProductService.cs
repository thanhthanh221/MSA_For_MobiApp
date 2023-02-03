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
            return null;

        }

        public Task<bool> CheckCategoryProduct(List<ProductCategory> productCategories)
        {
            throw new NotImplementedException();
        }
    }
}
using Market.Domain.ProductService.Commands.CreateProduct;
using Market.Domain.ProductService.Model;

namespace Market.Domain.ProductService.Services
{
    public interface IProductService
    {
        Task<ProductAggregate> AddProduct(CreateProductCommand createProductCommand);
        Task<bool> CheckCategoryProduct(List<ProductCategory> productCategories);  
    }
}
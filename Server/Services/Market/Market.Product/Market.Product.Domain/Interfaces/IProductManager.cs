using CategoryApi.Models;
using Market.Product.Domain.Commands.CreateProduct;
using Market.Product.Domain.Model;

namespace Market.Product.Domain.Interfaces
{
    public interface IProductManager
    {
        Task<ProductAggregate> CreateAsync(CreateProductCommand createProduct, List<CategoryClientRes> categories);
        Task<bool> CheckFavouriteProductAsync(ProductAggregate product, Guid userId);
    }
}
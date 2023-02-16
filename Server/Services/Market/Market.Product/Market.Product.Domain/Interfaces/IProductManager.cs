using Market.Product.Domain.Commands.CreateProduct;
using Market.Product.Domain.Model;

namespace Market.Product.Domain.Interfaces
{
    public interface IProductManager
    {
        Task<ProductAggregate> CreateAsync(CreateProductCommand createProduct);
        Task<bool> CheckFavouriteProductAsync(ProductAggregate product, Guid userId);
    }
}
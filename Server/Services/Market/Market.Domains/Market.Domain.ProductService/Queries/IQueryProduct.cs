using Market.Domain.ProductService.Extensions;
using Market.Domain.ProductService.Model;

namespace Market.Domain.ProductService.Queries
{
    public interface IQueryProduct
    {
        Task<List<ProductAggregate>> FilterByRequestQuery(FilterRequest filter);
        Task<List<ProductAggregate>> FilterByCategory(Guid CategoryId);
        Task<ProductAggregate> FilterById(Guid ProductId);
    }
}
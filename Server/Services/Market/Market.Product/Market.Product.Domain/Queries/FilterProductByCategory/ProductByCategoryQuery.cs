using Market.Product.Domain.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Market.Product.Domain.Queries.FindProductByCategory;

public class ProductByCategoryQuery : IRequest<List<ProductAggregate>>
{
    [Required]
    public Guid CategoryId { get; set; }
    [Required]
    public int Page { get; set; }
    [Required]
    public int PageSize { get; set; }
}

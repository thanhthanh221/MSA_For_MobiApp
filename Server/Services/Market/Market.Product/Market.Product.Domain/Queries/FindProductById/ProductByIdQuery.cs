using System.ComponentModel.DataAnnotations;
using Market.Product.Domain.Model;
using MediatR;

namespace Market.Product.Domain.Queries.FindProductById
{
    public class ProductByIdQuery : IRequest<ProductAggregate>
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}


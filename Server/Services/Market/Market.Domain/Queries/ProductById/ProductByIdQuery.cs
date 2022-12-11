using Market.Domain.Model;
using MediatR;

namespace Market.Domain.Queries.ProductById
{
    public class ProductByIdQuery : IRequest<Product>
    {
        public ProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId {get; private set;}
    }
}
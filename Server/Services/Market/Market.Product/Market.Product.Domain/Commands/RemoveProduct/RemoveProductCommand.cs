using MediatR;

namespace Market.Product.Domain.Commands.RemoveProduct
{
    public class RemoveProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
    }
}
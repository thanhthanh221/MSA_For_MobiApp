using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        [Required]
        public Guid ProductId {get; set;}
        [Required]
        public Guid UserId {get; set;}
    }
}
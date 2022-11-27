using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Commands.UpdateQuantityProduct
{
    public class UpdateQuantityProductCommand : IRequest<bool>
    {
        [Required]
        public Guid ProductId { get; set; }
        [Range(1, int.MaxValue)]
        [Required]
        public int NewQuantity { get; set; }
    }
}
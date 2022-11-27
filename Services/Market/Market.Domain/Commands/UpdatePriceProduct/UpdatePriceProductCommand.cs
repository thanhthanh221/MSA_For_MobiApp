using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Commands.UpdatePriceProduct
{
    public class UpdatePriceProductCommand  : IRequest<bool>
    {
        [Required]
        public Guid ProductId {get; set;}
        [Required]
        [Range(0, double.MaxValue)]
        public decimal NewPrice {get; set;}
        
    }
}
using Market.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Product>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Calo { get; set; }
        public string Descretion { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public HashSet<Guid> CategoriesId {get; set;}

        // user
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
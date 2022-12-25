using System.ComponentModel.DataAnnotations;
using Market.Domain.ProductService.Model;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Market.Domain.ProductService.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductAggregate>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Calo { get; set; }
        public string Descretion { get; set; }
        [Required]
        public string TypeName {get; set;}
        [Required]
    
        public string TypeProducts {get; set;}
        [Required]
        public TimeOrderProduct TimeOrder { get; set; }
        [Required]
        public List<Guid> CategoriesId { get; set; }

        // user
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
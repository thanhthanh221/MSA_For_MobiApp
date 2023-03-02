using System.ComponentModel.DataAnnotations;
using Market.Product.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Market.Product.Domain.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductAggregate>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Calo { get; set; }
        public string Descretion { get; set; }
        [Required]
        public TimeSpanOrderProduct TimeOrder { get; set; }
        [Required]
        public List<Guid> ListCateId { get; set; }
        [Required]
        public string TypeNameProduct {get; set;}
        [Required]
        public string ProductTypes { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }


    // Time Order

    public class TimeSpanOrderProduct
    {
        [Range(0, 31)]
        public int Day { get; set; }

        [Range(0, 60)]
        public int Hours { get; set; }

        [Required]
        [Range(0, 60)]
        public int Minute { get; set; }
    }
}
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
        public int Calo { get; set; }
        public string Descretion { get; set; }
        [Required]
        public string TypeName {get; set;}
        [Required]
    
        public List<string> TypeProducts {get; set;}
        [Required]
        public TimeOrderProduct TimeOrder { get; set; }
        [Required]
        public HashSet<Guid> CategoriesId { get; set; }

        // user
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }

    public class TimeOrderProduct
    {    
        [Required]
        [Range(0, 31)]
        public int Day { get; set; }

        [Required]
        [Range(0, 60)]
        public int Hours { get; set; }

        [Required]
        [Range(0, 60)]
        public int Minute { get; set; }
    }

}
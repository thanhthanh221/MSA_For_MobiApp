using System.ComponentModel.DataAnnotations;

namespace Market.Domain.ProductService.Commands.CreateProduct
{
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

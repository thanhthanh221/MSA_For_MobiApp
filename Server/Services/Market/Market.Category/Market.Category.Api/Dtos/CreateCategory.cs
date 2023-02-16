using System.ComponentModel.DataAnnotations;

namespace Market.Category.Api.Dtos
{
    public class CreateCategory
    {
        public CreateCategory()
        {
        }

        public CreateCategory(string name, IFormFile icon)
        {
            Name = name;
            Icon = icon;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile Icon { get; set; }

    }
}
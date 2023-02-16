using Market.Category.Api.Model;

namespace Market.Category.Api.Dtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public static CategoryDto ConverCategoryToDto(CategoryAggregate category)
        {
            return new CategoryDto() {
                Id = category.Id,
                Name = category.Name,
                Icon = $"https://localhost:7242/CategoryService/Category/CategoryIcon/{category.Id}"
            };
        }
    }
}
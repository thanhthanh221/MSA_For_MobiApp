using Market.Domain.Commands.CategoryCommand;

namespace Market.Domain.Validations.CategoryValidation
{
    public class CategoryCreateCommandValidation : CategoryValidation<CategoryCreateCommand>
    {
        public CategoryCreateCommandValidation()
        {
            ValidateId();
        }
    }
}

using Market.Domain.Validations.CategoryValidation;

namespace Market.Domain.Commands.CategoryCommand
{
    public class CategoryUpdateCommand : CategoryCommand
    {
        public CategoryUpdateCommand(Guid id,
                                        string name,
                                        string alias,
                                        string description,
                                        string image,
                                        DateTimeOffset updateAt,
                                        Guid updateBy)
        {
            Id = id;
            this.name = name;
            this.alias = alias;
            this.description = description;
            this.image = image;
            UpdateAt = updateAt;
            UpdateBy = updateBy;
        }
        public override bool IsValid()
        {
            ValidationResult = new CategoryUpdateValidationCommand().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

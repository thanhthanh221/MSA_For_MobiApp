using FluentValidation;

namespace Market.Domain.Commands.CreateCategory
{
    public class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommand>
    {
        public void ValidateName()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Phải có tên cho sản phẩm")
                .Length(2,20).WithMessage("Tên không được quá dài hay quá ngắn");
        }
    }
}

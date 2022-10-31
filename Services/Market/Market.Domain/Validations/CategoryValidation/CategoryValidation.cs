using FluentValidation;
using Market.Domain.Commands.CategoryCommand;

namespace Market.Domain.Validations.CategoryValidation
{
    public class CategoryValidation<T> : AbstractValidator<T> where T : CategoryCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Phải có Mã cho sản phẩm");
        }
        protected void ValidateAlias()
        {
            RuleFor(x =>x.alias)
                .NotEmpty().MinimumLength(1).WithMessage("Sản phẩm phải có tên");
        }
    }
}

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
    }
}

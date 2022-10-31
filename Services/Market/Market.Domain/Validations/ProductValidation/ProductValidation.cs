using FluentValidation;
using Market.Domain.Commands.ProductCommand;

namespace Market.Domain.Validations.ProductValidation
{
    public class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Phải có tên cho sản phẩm")
                .Length(2,100).WithMessage("Tên không được quá dài hay quá ngắn");
        }
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Phải có Mã cho sản phẩm");
        }

    }
}

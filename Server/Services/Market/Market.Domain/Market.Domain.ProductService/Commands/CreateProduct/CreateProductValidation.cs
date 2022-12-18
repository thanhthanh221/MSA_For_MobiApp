using FluentValidation;

namespace Market.Domain.ProductService.Commands.CreateProduct
{
    public class CreateProductValidation : AbstractValidator<CreateProductCommand>
    {
        public void ValidateName()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Phải có tên cho sản phẩm")
                .Length(2, 100).WithMessage("Tên không được quá dài hay quá ngắn");
        }
        public void ValidationCalo()
        {
            this.RuleFor(x => x.Calo)
                .NotEmpty().WithMessage("Không được Null giá trị")
                .GreaterThan(0).WithMessage("Calo không được âm");
        }

    }
}
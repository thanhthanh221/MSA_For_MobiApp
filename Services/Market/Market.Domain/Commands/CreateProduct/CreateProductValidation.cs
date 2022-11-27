using FluentValidation;

namespace Market.Domain.Commands.CreateProduct
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public void ValidateName()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Phải có tên cho sản phẩm")
                .Length(2,100).WithMessage("Tên không được quá dài hay quá ngắn");
        }
        public void ValidationCalo()
        {
            this.RuleFor(x => x.Calo)
                .NotEmpty().WithMessage("Không được Null giá trị")
                .GreaterThan(0).WithMessage("Calo không được âm");
        }
        public void ValidationPrice()
        {
            this.RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Phải có giá tiền sản phẩm")
                .GreaterThan(0).WithMessage("Phải có giá tiền");
        }
    }
}
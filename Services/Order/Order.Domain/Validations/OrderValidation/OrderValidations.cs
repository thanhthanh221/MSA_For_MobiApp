using FluentValidation;
using Order.Domain.Commands.OrderCommand;

namespace Order.Domain.Validations.OrderValidation
{
    public class OrderValidations<T> : AbstractValidator<T> where T : OrderCommands
    {
        protected void ValidateAddress()
        {
            RuleFor(x => x.address)
                .NotEmpty()
                .WithMessage("Phải có địa chỉ !");
        }
        //orderItems

        protected void ValidateOrderItem()
        {
            RuleFor(x => x.orderItemCommands)
                .NotEmpty()
                .WithMessage("Đơn hàng phải có sản phẩm !");
        }

        protected void ValidateUserId()
        {
            RuleFor(x => x.orderItemCommands)
                .NotEmpty()
                .WithMessage("Đơn hàng phải có người mua !");
        } 
    }
}

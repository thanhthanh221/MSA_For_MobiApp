using FluentValidation;

namespace Order.Domain.Commands.SetOrderStatus
{ 
    public class SetOrderStatusCommandValidation : AbstractValidator<SetOrderStatusCommand>
    {
        public SetOrderStatusCommandValidation()
        {
            RuleFor(x => x.orderStatusId)
                .NotEmpty()
                .WithMessage("Đơn hàng phải có sản phẩm !");

            RuleFor(x => x.orderStatusId)
                .GreaterThan(0)
                .LessThan(7)
                .WithMessage("Chỉ được trong khoảng 1 -> 6 !");
        }
    }
}

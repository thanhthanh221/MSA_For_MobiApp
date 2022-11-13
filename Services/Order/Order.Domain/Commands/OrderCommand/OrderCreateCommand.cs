using Order.Domain.Model;
using Order.Domain.Validations.OrderValidation;

namespace Order.Domain.Commands.OrderCommand
{
    public class OrderCreateCommand : OrderCommands
    {
        public OrderCreateCommand(Guid userId,
                                  String description,
                                  Boolean isDraft,
                                  OrderStatus orderStatus,
                                  Address address,
                                  List<OrderItemWriteCommand> orderItemCommands,
                                  Guid CreateBy)
        {
            this.userId = userId;
            this.description = description;
            this.isDraft = isDraft;
            this.orderItemCommands = orderItemCommands;
            this.orderStatus = orderStatus;
            this.CreateBy = CreateBy;
            this.CreateAt = DateTime.UtcNow;
        }

        public override bool IsValid()
        {
            // Check xem dữ liệu có hợp lệ không
            ValidationResult = new OrderCreateCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}

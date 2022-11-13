using Order.Domain.Core.Bus;
using Order.Domain.Core.Commands;
using Order.Domain.Model;
using Order.Domain.Validations.OrderValidation;

namespace Order.Domain.Commands.OrderCommand
{
    public class OrderUpdateCommand : OrderCommands
    {
        public OrderUpdateCommand(Guid Id,
                                  Guid userId,
                                  String description,
                                  Boolean isDraft,
                                  OrderStatus orderStatus,
                                  Address address,
                                  List<OrderItemWriteCommand> orderItemCommands,
                                  Guid UpdateBy)
        {
            this.Id = Id;
            this.userId = userId;
            this.description = description;
            this.isDraft = isDraft;
            this.orderStatus = orderStatus;
            this.orderItemCommands = orderItemCommands;
            this.address = address;
            this.UpdateBy = UpdateBy;
            this.UpdateAt = DateTime.UtcNow;
        }

        public override bool IsValid()
        {
            // Check xem dữ liệu có hợp lệ không
            ValidationResult = new OrderUpdateCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}

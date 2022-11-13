using Order.Domain.Core.Commands;
using Order.Domain.Model;

namespace Order.Domain.Commands.OrderCommand
{
    public class OrderItemWriteCommand
    {
        public Guid productId { get; init; }
        public decimal discount { get; init; }
        public int count { get; set; }
    }
    public abstract class OrderCommands : Command
    {
        public Guid Id { get; protected set; }
        public Guid userId { get; protected set; }
        public String description { get; protected set; }
        public Boolean isDraft { get; protected set; }
        // Enum
        public OrderStatus orderStatus { get; protected set; }
        // Value Object
        public Address address { get; protected set; }

        // 1 - N
        public List<OrderItemWriteCommand> orderItemCommands { get; protected set; }

        // Info Entity
        public Guid CreateBy { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public Guid UpdateBy { get; protected set; }
        public DateTime UpdateAt { get; protected set; }

    }
}

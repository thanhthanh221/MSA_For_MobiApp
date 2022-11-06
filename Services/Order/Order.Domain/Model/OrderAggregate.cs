using Order.Domain.Core.Models;

namespace Order.Domain.Model
{
    // Root Aggregate Order
    public class OrderAggregate : EntityAudit, IAggregateRoot
    {
        public Guid userId { get; private set; }
        public String userName {get; private set;}
        public String description { get; private set; }
        public Boolean isDraft { get; private set; } 
        // Enum
        public OrderStatus orderStatus { get; private set; }
        public int orderStatusId { get; private set; }
        // Value Object
        public Address address { get; private set; }

        // 1 - N
        public List<OrderItem> orderItems { get; private set; }

        public OrderAggregate()
        {
        }

        public OrderAggregate(Guid userId,
                              String userName,
                              String description,
                              bool isDraft,
                              OrderStatus orderStatus,
                              int orderStatusId,
                              Address address)
        {
            this.userId = userId;
            this.userName = userName;
            this.description = description;
            this.isDraft = isDraft;
            this.orderStatus = orderStatus;
            this.orderStatusId = orderStatusId;
            this.address = address;
            this.orderItems = orderItems;
        }
        // tạo bản order nháp
        public static OrderAggregate NewDraft()
        {
            OrderAggregate order = new OrderAggregate();
            order.isDraft = true;
            return order;
        }

        // Nghiệp vụ thêm đơn hàng
        public void AddOrderItem(Guid productId, String productName, String image, decimal price, decimal discount, int count)
        {
            OrderItem orderItem = orderItems
                                .Where(orItem => orItem.productId == productId)
                                .SingleOrDefault();

            if(orderItem != null)
            {
                orderItem.count += count;
            }
            else 
            {
                OrderItem newOrderItem = new OrderItem(productId,
                                                productName,
                                                image,
                                                price,
                                                discount,
                                                count,
                                                this.Id
                                                );
                // Add 
                orderItems.Add(newOrderItem);
            }
        }
    }
}

using Order.Domain.Core.Models;

namespace Order.Domain.Model
{
    public class OrderItem : EntityAudit
    {
        public OrderItem()
        {
        }

        public OrderItem(OrderAggregate order,
                         Guid productId,
                         string productName,
                         string image,
                         decimal price,
                         int count)
        {
            this.order = order;
            this.productId = productId;
            this.productName = productName;
            this.image = image;
            this.price = price;
            this.count = count;
        }
        
        // Product Infomation
        public Guid productId { get; private set; }
        public string productName { get; private set; }
        public decimal price { get; private set; }
        public string image { get; private set; }

        // Count
        public int count { get; set; }

        // Order Aggregate
        public Guid orderId { get; private set; }
        public virtual OrderAggregate order { get; private set; }
    }
}

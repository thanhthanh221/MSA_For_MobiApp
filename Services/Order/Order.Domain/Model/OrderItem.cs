using Order.Domain.Core.Models;

namespace Order.Domain.Model
{
    public class OrderItem : EntityAudit
    {
        public OrderItem()
        {
        }

        public OrderItem(Guid productId,
                         string productName,
                         string image,
                         decimal price,
                         decimal discount,
                         int count,
                         Guid orderId)
        {
            this.productId = productId;
            this.productName = productName;
            this.image = image;
            this.price = price;
            this.discount = discount;
            this.count = count;
            this.orderId = orderId;
        }
        public Guid orderId { get; private set; }
        public Guid productId { get; private set; }
        public string productName { get; private set; }
        public string image { get; private set; }
        public decimal price { get; private set; }
        public decimal discount { get; private set; }
        public int count { get; set; }

        // Order Aggregate
        public OrderAggregate order { get; private set; }
    }
}

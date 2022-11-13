namespace EventBus.Messages.Events
{
    public class OrderItemCheckoutEvent
    {
        public OrderItemCheckoutEvent(Guid productId, int count)
        {
            this.productId = productId;
            this.count = count;
        }

        public Guid productId { get; set; }
        public string productName { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; } // giá được giảm => phải có phiếu giảm giá
        public int count { get; set; }

    }
}
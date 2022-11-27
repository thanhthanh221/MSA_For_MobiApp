using Order.Domain.Core.Models;

namespace Order.Domain.Model
{
    // Root Aggregate Order
    public class OrderAggregate : EntityAudit, IAggregateRoot
    {
        public String orderName { get; private set; }
        public DateTime createAt { get; private set; }
        public decimal price { get; private set; }

        // user Infomation
        public Guid userId { get; private set; }
        public String userName { get; private set; }

        // 1 - N
        public virtual List<OrderItem> orderItems { get; private set; }

        // OrderStatus N - 1
        public int? orderStatusId { get; private set; }
        public virtual OrderStatus orderStatus { get; private set; }

        // Value Obj
        public virtual Address address { get; private set; }


        public OrderAggregate()
        {
        }

        public OrderAggregate(Guid userId,
                              string userName)
        {
            this.orderName = Guid.NewGuid().ToString().Substring(1, 5);
            this.userId = userId;
            this.userName = userName;
            this.orderStatusId = OrderStatus.Submitted.Id;
            this.createAt = DateTime.Now;
        }

        // Nghiệp vụ thêm đơn hàng
        public void AddOrderItem(Guid productId, String productName, String image, decimal price, int count)
        {
            if(this.orderItems is null) 
            {
                this.orderItems = new List<OrderItem>();
                OrderItem newOrderItem = new OrderItem(this, productId, productName, image, price, count);
                // Add 
                this.orderItems.Add(newOrderItem);
            }
            OrderItem orderItem = this.orderItems
                                .Where(or => or.productId == productId)
                                .SingleOrDefault();
                
            // Nếu đơn hàng chưa có sản phẩm 
            if (orderItem is null) {

                OrderItem newOrderItem = new OrderItem(this, productId, productName, image, price, count);
                // Add 
                this.orderItems.Add(newOrderItem);

                return;
            }
            orderItem.count += count;
        }

        // Tính tiền đơn hàng
        public void OrderBilling()
        {
            this.price = this.orderItems.Sum(orItem => orItem.price);
        }

        // Thay đổi địa chỉ đơn hàng
        public void UpdateAddress(string city, string district, string commune, string street, string detail)
        {
            Address newAddress = new Address(city, district, commune, street, detail, this);
            if(this.address is null)
            {
                this.address = address;
            }

            if(!newAddress.Equals(address))
            {
                this.address = newAddress;
            }
        }

        public void SetShippedStatus()
        {
            if (this.orderStatusId != OrderStatus.Shipped.Id) {
                this.orderStatus = OrderStatus.Shipped;

                // Sinh ra Event 
            }
        }

        public void SetCancellOrder()
        {
            if (this.orderStatusId <= 3) {
                this.orderStatus = OrderStatus.Cancelled;
            }
        }
    }
}

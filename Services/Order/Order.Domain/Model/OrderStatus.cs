using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Domain.Core.Models;

namespace Order.Domain.Model
{
    public class OrderStatus : Enumeration
    {
        // Prop

        /*
            Đang chờ xác thực
            Đang chuẩn bị
            Đã vận chuyển
            Đánh giá
            Huy don hang
        */
        public static OrderStatus Submitted = new OrderStatus(1, "Xác nhận đặt hàng", "Đơn đặt hàng của bạn đã được nhận");
        public static OrderStatus Prepared = new OrderStatus(2, "Đơn hàng đang chuẩn bị","Đơn đặt hàng của bạn đã được chuẩn bị");
        public static OrderStatus StockConfirmed = new OrderStatus(3, "Đang giao hàng", "Đơn hàng của bạn đang được chuyển đến");
        public static OrderStatus Shipped = new OrderStatus(4, "Đã giao hàng", "Chúc bạn ăn ngon miệng");
        public static OrderStatus Evaluate = new OrderStatus(5, "Đánh giá chúng tôi", "Giúp chúng tôi cải thiện dịch vụ của mình");
        public static OrderStatus Cancelled = new OrderStatus(6, "Hủy Đơn hàng", "Hẹn gặp lại bạn đơn hàng khác");

        public virtual List<OrderAggregate> orders {get; private set;}

        public OrderStatus(int Id, string name, string sub_title) : base(Id, name, sub_title)
        {
        }


        // Full OrderStatus 
        public static IEnumerable<OrderStatus> FullOrderStatus()
        {
            return new[]
            {
                Submitted, 
                Prepared, 
                StockConfirmed, 
                Shipped, 
                Evaluate
            };
        }        
    }
}

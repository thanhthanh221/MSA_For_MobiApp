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
            Trả
            Đã vận chuyển
            Đánh giá
        */
        public static OrderStatus Submitted = new OrderStatus(1, nameof(Submitted).ToLower());
        public static OrderStatus Prepared = new OrderStatus(2, nameof(Prepared).ToLower());
        public static OrderStatus StockConfirmed = new OrderStatus(3, nameof(StockConfirmed).ToLower());
        public static OrderStatus Paid = new OrderStatus(4, nameof(Paid).ToLower());
        public static OrderStatus Shipped = new OrderStatus(5, nameof(Shipped).ToLowerInvariant());
        public static OrderStatus Evaluate = new OrderStatus(6, nameof(Evaluate).ToLowerInvariant());


        public OrderStatus(int Id, string name) : base(Id, name)
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
                Paid, 
                Shipped, 
                Evaluate
            };
        }
    }
}

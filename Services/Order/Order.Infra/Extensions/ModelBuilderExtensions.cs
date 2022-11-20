using Microsoft.EntityFrameworkCore;
using Order.Domain.Model;

namespace Order.Infra.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>().HasData(
                OrderStatus.Submitted,
                OrderStatus.Prepared,
                OrderStatus.StockConfirmed,
                OrderStatus.Shipped,
                OrderStatus.Evaluate,
                OrderStatus.Cancelled
            );
            
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Order.Domain.Model;

namespace Order.Infra.EntityConfigurations
{
    public class OrderItemConfigutation : IEntityTypeConfiguration<OrderItem>
    {
        // Config By fur Api For OrderItem
        public void Configure(EntityTypeBuilder<OrderItem> orderItemConfig)
        {
            // Table 
            orderItemConfig.ToTable("Sản phẩm đơn hàng");

            // ConfigKey 
            orderItemConfig.HasKey(orderIt => orderIt.Id);

            // Bỏ qua trường => không có event lưu trong Sql
            orderItemConfig.Ignore(orderIt => orderIt.domainEvent);

            // Name Column
            orderItemConfig.Property(orderIt => orderIt.productId)
                .HasColumnName("Mã sản phẩm")
                .HasColumnType("varchar(255)")
                .IsRequired();

            orderItemConfig.Property(orderIt => orderIt.productName)
                .HasColumnName("Tên sản phẩm")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            orderItemConfig.Property(orderIt => orderIt.price)
                .HasColumnName("Giá")
                .HasColumnType("DECIMAL")
                .IsRequired();

            orderItemConfig.Property(orderIt => orderIt.image)
                .HasColumnName("Ảnh")
                .HasColumnType("text")
                .IsRequired();

            orderItemConfig.Property(orderIt => orderIt.count)
                .HasColumnName("Số lượng")
                .IsRequired();

            orderItemConfig.Property(orderIt => orderIt.orderId)
                .HasColumnName("Mã đơn hàng")
                .IsRequired();

            // 1 - N order Agg
            orderItemConfig.HasOne(o => o.order)
                .WithMany(o => o.orderItems)
                .HasForeignKey(o => o.orderId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

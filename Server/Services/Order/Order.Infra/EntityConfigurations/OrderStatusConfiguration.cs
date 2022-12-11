using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Model;

namespace Order.Infra.EntityConfigurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> orderStatusConfig)
        {
            // Name Table
            orderStatusConfig.ToTable("Trạng thái đơn hàng");

            // Key
            orderStatusConfig.HasKey(orderStatus => orderStatus.Id);

            // Column Name
            orderStatusConfig.Property(orStatus => orStatus.name)
                .HasColumnName("Trạng thái Đơn hàng")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            orderStatusConfig.Property(orStatus => orStatus.sub_title)
                .HasColumnName("Thông tin đơn hàng")
                .HasColumnType("nvarchar(150)")
                .IsRequired();

        }
    }
}

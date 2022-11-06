using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Model;
using Order.Infra.Data.Data;

namespace Order.Infra.Data.EntityConfigurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> orderStatusConfig)
        {
            // Name Table
            orderStatusConfig.ToTable("Trạng thái đơn hàng");

            // Key
            orderStatusConfig.HasKey(orderStatus => orderStatus.Id);
            orderStatusConfig.Property(orderStatus => orderStatus.Id)
                .HasColumnType("varchar(20)");

            // Column Name
            orderStatusConfig.Property(orStatus => orStatus.name)
                .HasColumnName("Trạng thái Đơn hàng")
                .IsRequired();

        }
    }
}

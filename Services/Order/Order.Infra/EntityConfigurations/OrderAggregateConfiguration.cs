using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Model;

namespace Order.Infra.EntityConfigurations
{
    public class OrderAggregateConfiguration : IEntityTypeConfiguration<OrderAggregate>
    {
        public void Configure(EntityTypeBuilder<OrderAggregate> orderAggregateConfig)
        {

            orderAggregateConfig.ToTable("Đơn hàng");

            // Key
            orderAggregateConfig.HasKey(orderAgg => orderAgg.Id);

            orderAggregateConfig.Ignore(orderAgg => orderAgg.domainEvent);  

            // Name Column
            orderAggregateConfig.Property(orderAgg => orderAgg.userId)
                .IsRequired();

            orderAggregateConfig.Property(orAgg => orAgg.orderStatusId)
                .HasColumnName("Mã trạng thái");


            orderAggregateConfig.Property(orderAgg => orderAgg.userName)
                .HasColumnType("varchar(255)")
                .HasColumnName("Tên Người Đặt hàng")
                .IsRequired();

            orderAggregateConfig.Property(orAgg => orAgg.price)
                .HasColumnName("Giá")
                .HasColumnType("decimal")
                .IsRequired();

            orderAggregateConfig.Property(orAgg => orAgg.orderName)
                .HasColumnType("varchar(255)")
                .HasColumnName("Tên đơn hàng")
                .IsRequired();

            orderAggregateConfig.Property(orAgg => orAgg.userId)
                .HasColumnType("varchar(255)")
                .HasColumnName("Mã người đặt")
                .IsRequired();

            orderAggregateConfig.Property(orAgg => orAgg.createAt)
                .HasColumnType("DATETIME")
                .HasColumnName("Thời gian tạo")
                .IsRequired();

            // 1 -N => Stus
            orderAggregateConfig.HasOne(orderAgg => orderAgg.orderStatus)
                .WithMany(orStatus => orStatus.orders)
                .HasForeignKey(orderAgg => orderAgg.orderStatusId);
        }
    }
}

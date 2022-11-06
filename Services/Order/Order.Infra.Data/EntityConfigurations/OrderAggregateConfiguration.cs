using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Model;

namespace Order.Infra.Data.EntityConfigurations
{
    public class OrderAggregateConfiguration : IEntityTypeConfiguration<OrderAggregate>
    {
        public void Configure(EntityTypeBuilder<OrderAggregate> orderAggregateConfig)
        {
            // Table Name
            orderAggregateConfig.ToTable("Đơn Hàng");

            // Key
            orderAggregateConfig.HasKey(orderAgg => orderAgg.Id);
            orderAggregateConfig.Property(orderAgg => orderAgg.Id).HasColumnType("varchar(20)");

            orderAggregateConfig.Ignore(orderAgg => orderAgg.domainEvent);

            // Address
            orderAggregateConfig
            .OwnsOne(o => o.address, a => {
                a.WithOwner(); // tham chiếu ngược lại
                
                a.Property(add => add.city)
                .HasColumnName("Thành phố/Tỉnh")
                .IsRequired(false);

                a.Property(add => add.district)
                .HasColumnName("Quận/Huyện")
                .IsRequired(false);

                a.Property(add => add.street)
                .HasColumnName("Đường")
                .IsRequired(false);

                a.Property(add => add.commune)
                .HasColumnName("Xã/Phường")
                .IsRequired(false);

                a.Property(add => add.infomation)
                .HasColumnName("Địa chỉ")
                .IsRequired(false);
            });


            // Name Column
            orderAggregateConfig.Property(orderAgg => orderAgg.userId)
                .HasColumnName("Mã người mua")
                .IsRequired();

            orderAggregateConfig.Property(orderAgg => orderAgg.description)
                .HasColumnName("Mô tả đơn hàng")
                .IsRequired(false);

            orderAggregateConfig.Property(orderAgg => orderAgg.isDraft)
                .HasColumnName("Đã lưu")
                .IsRequired();

            orderAggregateConfig.Property(orderAgg => orderAgg.orderStatusId)
                .HasColumnName("Mã trạng thái")
                .IsRequired();

            orderAggregateConfig.Property(orderAgg => orderAgg.userName)
                .HasColumnName("Tên người mua")
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            // 1 -N => Stus
            orderAggregateConfig.HasOne(orderAgg => orderAgg.orderStatus)
                .WithMany()
                .HasForeignKey(orderAgg => orderAgg.orderStatusId);
        }
    }
}

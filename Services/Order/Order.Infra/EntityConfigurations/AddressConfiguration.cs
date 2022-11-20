using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Model;

namespace Order.Infra.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Địa chỉ");

            builder.HasKey(add => add.orderId);

            builder.Property(add => add.city)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("Thành phố/Tỉnh")
                .IsRequired();

            builder.Property(add => add.district)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("Quận/Huyện")
                .IsRequired();

            builder.Property(add => add.commune)
                .HasColumnName("Xã/Phường")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(add => add.street)
                .HasColumnName("Đường")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(add => add.detail)
                .HasColumnName("Địa chỉ")
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            // 1 - 1 Order
            builder.HasOne(add => add.order)
                .WithOne(or => or.address)
                .HasForeignKey<Address>(add => add.orderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
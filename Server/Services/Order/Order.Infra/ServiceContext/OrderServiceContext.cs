using Microsoft.EntityFrameworkCore;
using Order.Domain.Model;
using Order.Infra.EntityConfigurations;
using Order.Infra.Extensions;

namespace Order.Infra.ServiceContext
{
    public class OrderServiceContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Application.Order";

        //DbSet For Db
        public virtual DbSet<OrderItem> orderItems { get; set; }
        public virtual DbSet<OrderAggregate> orders { get; set; }
        public virtual DbSet<OrderStatus> orderStatuses { get; set; }
        public virtual DbSet<Address> Addresses {get; set;}

        // Settings Overrding
        public OrderServiceContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderAggregateConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfigutation());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
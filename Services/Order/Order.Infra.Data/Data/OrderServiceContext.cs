using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Order.Domain.Model;
using Order.Infra.Data.EntityConfigurations;

namespace Order.Infra.Data.Data
{
    public class OrderServiceContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Application.Ordering";

        //DbSet For Db
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<OrderAggregate> orders { get; set; }
        public DbSet<OrderStatus> orderStatuses { get; set; }

        // Settings Overrding
        public OrderServiceContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderAggregateConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfigutation());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

    // Create DB
    public class OrderServiceContextFactory : IDesignTimeDbContextFactory<OrderServiceContext>
    {
        public OrderServiceContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OrderServiceContext> optionsBuilder = new DbContextOptionsBuilder<OrderServiceContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=Order_Api;User ID=SA;Password=Password123");

            return new OrderServiceContext(optionsBuilder.Options);
        }
    }
}

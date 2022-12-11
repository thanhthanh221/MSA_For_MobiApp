using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Order.Infra.ServiceContext
{
    public class OrderServiceContextFactory : IDesignTimeDbContextFactory<OrderServiceContext>
    {
        public OrderServiceContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("Context");
            DbContextOptionsBuilder<OrderServiceContext> optionsBuilder = new();

            optionsBuilder.UseSqlServer(connectionString);

            return new OrderServiceContext(optionsBuilder.Options);
        }
    }
}
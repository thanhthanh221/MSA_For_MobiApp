using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Order.Infra.ServiceContext
{
    public class OrderServiceContextFactory : IDesignTimeDbContextFactory<OrderServiceContext>
    {
        public OrderServiceContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            String connectionString = configuration.GetConnectionString("Context");
            DbContextOptionsBuilder<OrderServiceContext> optionsBuilder = new DbContextOptionsBuilder<OrderServiceContext>();
        
            optionsBuilder.UseSqlServer(connectionString);

            return new OrderServiceContext(optionsBuilder.Options);
        }
    }
}
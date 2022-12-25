using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Identity.Infra.ServiceContext
{
    public class IdentityServiceContextFactory : IDesignTimeDbContextFactory<IdentityServiceContext>
    {
        public IdentityServiceContext CreateDbContext(string[] args)
        {
           var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("Context");
            DbContextOptionsBuilder<IdentityServiceContext> optionsBuilder = new();

            optionsBuilder.UseSqlServer(connectionString);

            return new IdentityServiceContext(optionsBuilder.Options);
        }
    }
}
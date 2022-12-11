using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Order.Domain.Interface;
using Order.Infra.Repository;
using Order.Infra.ServiceContext;
using Order.Infra.UnitOW;

namespace Order.Application.Installers
{
    public class EFInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Unit Of Work
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            // Repository 
            services.AddScoped<IOrderRepository, OrderRepository>();
            // Add DbContext using Sql server
            services.AddDbContext<OrderServiceContext>(options =>{
                string sqlConfig = configuration.GetConnectionString("Context");
                options.UseSqlServer(sqlConfig);
            });
        }
    }
}

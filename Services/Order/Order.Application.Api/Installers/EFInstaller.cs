using Microsoft.EntityFrameworkCore;
using Order.Domain.Interface;
using Order.Infra.Data.Data;
using Order.Infra.Data.UnitOW;

namespace Order.Application.Api.Installers
{
    public class EFInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Unit Of Work
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            // Add DbContext using Sql server
            services.AddDbContext<OrderServiceContext>(options =>{
                string sqlConfig = configuration.GetConnectionString("Context");
                options.UseSqlServer(sqlConfig);
            });
        }
    }
}

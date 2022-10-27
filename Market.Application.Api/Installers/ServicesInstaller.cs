using Market.Application.Interfaces;
using Market.Application.Services;

namespace Market.Application.Api.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductServices, ProductServies>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}

using Application.Common.Extensions;
using Identity.Domain.Interfaces;
using Identity.Domain.Services;

namespace Identity.Api.Installers
{
    public class DomainInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IManageService, ManageService>();
        }
    }
}
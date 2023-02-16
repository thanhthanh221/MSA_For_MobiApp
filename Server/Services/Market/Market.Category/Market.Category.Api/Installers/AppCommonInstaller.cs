using Application.Common.Extensions;
using Application.Common.Installer;

namespace Market.Category.Api.Installers
{
    public class AppCommonInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddAuthenticationInCommon();
            services.AddSystemBase();
        }
    }
}
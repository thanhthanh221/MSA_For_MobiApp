using Application.Common.Extensions;
using Application.Common.Installer;

namespace Identity.Api.Installers
{
    public class AppCommonInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
           services.AddSystemBase();
           services.AddClientApi();
        }
    }
}
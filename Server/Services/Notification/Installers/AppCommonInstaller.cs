using Application.Common.Extensions;
using Application.Common.Installer;

namespace Notification.Installers
{
    public class AppCommonInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSystemBase();
            services.AddAuthenticationInCommon();
        }
    }
}
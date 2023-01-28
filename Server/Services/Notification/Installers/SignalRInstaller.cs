using Application.Common.Extensions;

namespace Notification.Installers
{
    public class SignalRInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSignalR();
        }
    }
}
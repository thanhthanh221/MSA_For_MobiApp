using Application.Common.Extensions;
using Message.Interfaces;
using Message.Services;
using Message.Settings;

namespace Message.Installers
{
    public class SendMailInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var mailsettings = configuration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailsettings); 

            services.AddTransient<ISendMailService, SendMailService>();
        }
    }
}

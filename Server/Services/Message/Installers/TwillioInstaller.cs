using Application.Common.Extensions;
using Twilio;

namespace Message.Installers
{
    public class TwillioInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Get Twilio configuration section
            var twilioSection = configuration.GetSection("Twilio");
            // Read Twilio account details
            string accountSid = twilioSection["AccountSid"];
            string authToken = twilioSection["AuthToken"];
            // Initialize Twilio client
            TwilioClient.Init(accountSid, authToken);
        }
    }
}

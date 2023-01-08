using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Installer
{
    public static class ClientApiInstaller
    {
        public static IServiceCollection AddClientApi(this IServiceCollection services)
        {
            // Add the HttpClient service
            services.AddHttpClient();
            return services;
        }
    }
}
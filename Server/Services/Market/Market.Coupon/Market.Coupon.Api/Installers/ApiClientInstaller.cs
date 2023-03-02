using Application.Common.Extensions;
using UserApi.Client;

namespace Market.Coupon.Api.Installers
{
    public class ApiClientInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.InstallUserClient();
        }
    }
}
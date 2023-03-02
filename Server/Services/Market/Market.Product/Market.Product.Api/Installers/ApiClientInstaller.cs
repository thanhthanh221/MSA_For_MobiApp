using Application.Common.Extensions;
using CategoryApi.Client;
using UserApi.Client;

namespace Market.Product.Api.Installers
{
    public class ApiClientInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.InstallCategoryClient();
            services.InstallUserClient();
        }
    }
}

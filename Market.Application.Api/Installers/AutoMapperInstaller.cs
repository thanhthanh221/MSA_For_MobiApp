using Market.Application.Mapper;

namespace Market.Application.Api.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(ConfigMapper.RegisterMappings());
        }
    }
}

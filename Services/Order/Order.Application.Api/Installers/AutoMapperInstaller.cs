using Order.Application.Mapper;

namespace Order.Application.Api.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(ConfigMapper.RegisterMappings());
        }
    }
}

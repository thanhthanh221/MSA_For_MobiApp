using Order.Application.Mapper;
using Order.Domain.Mapper;

namespace Order.Application.Api.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Application Mapper
            services.AddAutoMapper(ConfigMapper.RegisterMappings());

            // Command Mapper
            services.AddAutoMapper(ConfigCommandMapper.RegisterMappings());

        }
    }
}

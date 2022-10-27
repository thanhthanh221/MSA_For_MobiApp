using Market.Application.Mapper;
using Market.Domain.Mapper;

namespace Market.Application.Api.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(ConfigMapper.RegisterMappings());
            services.AddAutoMapper(ConfigCommandMapper.CommandMappings());
        }
    }
}

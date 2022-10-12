namespace Market.Application.Api.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}

namespace Market.Application.Installers
{
    public class CorsInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
        }
    }
}

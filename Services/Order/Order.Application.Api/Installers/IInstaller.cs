namespace Order.Application.Api.Installers
{
    public interface IInstaller 
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}

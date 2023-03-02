using Application.Common.Extensions;

namespace Market.Coupon.Api.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallerServiceInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            List<IInstaller> installer = typeof(Program).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installer.ForEach(install => install.InstallService(services, configuration));
        }
    }
}
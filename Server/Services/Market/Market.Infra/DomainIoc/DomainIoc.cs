using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Infra.DomainIoc
{
    public static class DomainIoc
    {
        public static void AddDomainIoc(IServiceCollection services, IConfiguration configuration)
        {
            AddDomainCommandIoc(services, configuration);
            AddDomainEventIoc(services, configuration);
            AddQueriesIoc(services, configuration);
            AddServices(services, configuration);

        }
        private static void AddDomainCommandIoc(IServiceCollection services, IConfiguration configuration)
        {

        }
        private static void AddDomainEventIoc(IServiceCollection services, IConfiguration configuration)
        {

        }
        private static void AddQueriesIoc(IServiceCollection services, IConfiguration configuration)
        {

        }
        private static void AddServices(IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}

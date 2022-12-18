using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Infra.DomainIoc
{
    public class DomainIoc
    {
        public void AddDomainIoc(IServiceCollection services, IConfiguration configuration)
        {
            AddDomainCommandIoc(services, configuration);
            AddDomainEventIoc(services, configuration);

        }
        private static void AddDomainCommandIoc(IServiceCollection services, IConfiguration configuration)
        {

        }
        private static void AddDomainEventIoc(IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}

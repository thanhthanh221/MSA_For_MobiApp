using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Market.Infra.Masstransit
{
    public interface IMasstransitExtension
    {
        void ConfigRabbitMq(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configuration);
    }
    
}

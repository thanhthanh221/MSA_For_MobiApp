using EventBus.Messages.Events;
using MassTransit;
using MassTransit.RabbitMqTransport;
using RabbitMQ.Client;

namespace Market.Infra.Masstransit
{
    public class MasstransitPublish : IMasstransitExtension
    {
        public void ConfigRabbitMq(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configuration)
        {
            CreateOrderPublish(context, configuration);
        }

        public static void CreateOrderPublish(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configuration)
        {
            configuration.Send<OrderCheckoutEvent>(x => {
                x.UseRoutingKeyFormatter(context => "15122001");
            });
            configuration.Message<OrderCheckoutEvent>(x => {
                x.SetEntityName("Market.Checkout");
            });
            configuration.Publish<OrderCheckoutEvent>(x => {
                x.ExchangeType = ExchangeType.Direct;
            });
        }
    }
}

using Market.Domain.ProductService.Consumer;
using MassTransit;
using MassTransit.RabbitMqTransport;
using RabbitMQ.Client;

namespace Market.Infra.Masstransit
{
    public class MasstransitConsumer : IMasstransitExtension
    {
        public void ConfigRabbitMq(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configuration)
        {
            CreateOrderConsumer(context, configuration);
        }
        private static void CreateOrderConsumer(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configuration)
        {
            configuration.ReceiveEndpoint("Order-Services", e => {
                e.ConfigureConsumer<OrderCheckoutConsumer>(context);

                e.Bind("Order.Orchestration", x => {
                    x.AutoDelete = false;
                    x.Durable = true;
                    x.ExchangeType = ExchangeType.Direct;
                    x.RoutingKey = "16042002";
                });
            });

        }
    }
}

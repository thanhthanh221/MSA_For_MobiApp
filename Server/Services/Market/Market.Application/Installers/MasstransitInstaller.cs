using System.Reflection;
using EventBus.Messages.Events;
using Market.Application.Consumers;
using Market.Infra.Settings;
using MassTransit;
using RabbitMQ.Client;

namespace Market.Application.Installers
{
    public class MasstransitInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(configure => {
                configure.AddConsumers(Assembly.GetEntryAssembly());

                // IBusRegistrationContext  -- IRabbitMqBusFactoryConfigurator 

                // cài đặt khi sử dung rbmq
                configure.UsingRabbitMq((context, configuration) => {

                    IConfiguration Configuration = context.GetService<IConfiguration>();

                    RabbitMQSettings rabbitMQSettings = Configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();

                    // Config RabbitMq By Masstransit
                    configuration.Host(rabbitMQSettings.Host, "/", h => {
                        h.Username(rabbitMQSettings.Username);
                        h.Password(rabbitMQSettings.Password);
                    });

                    configuration.Send<OrderCheckoutEvent>(x => {
                        x.UseRoutingKeyFormatter(context => "15122001");
                    });
                    configuration.Message<OrderCheckoutEvent>(x => {
                        x.SetEntityName("Market.Checkout");
                    });
                    configuration.Publish<OrderCheckoutEvent>(x => {
                        x.ExchangeType = ExchangeType.Direct;
                    });


                    configuration.ReceiveEndpoint("Order-Services", e => {
                        e.ConfigureConsumer<OrderCreactedConsumer>(context);

                        e.Bind("Order.Orchestration", x => {
                            x.AutoDelete = false;
                            x.Durable = true;
                            x.ExchangeType = ExchangeType.Direct;
                            x.RoutingKey = "16042002";
                        });
                    });



                    // Exchange for Consume 
                });
            });
            services.AddMassTransitHostedService();

        }
    }
}

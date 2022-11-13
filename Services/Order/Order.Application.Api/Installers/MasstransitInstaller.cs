using EventBus.Messages.Events;
using MassTransit;
using Order.Application.Api.Consumers;
using Order.Domain.Events.OrderEvent;
using Order.Infra.Data.Settings;
using RabbitMQ.Client;

namespace Order.Application.Api.Installers
{
    public class MasstransitInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(configure => {

                configure.AddConsumer<OrderCheckoutConsumer>();

                // cài đặt khi sử dung rbmq
                configure.UsingRabbitMq((context, configuration) => {

                    IConfiguration Configuration = context.GetService<IConfiguration>();

                    RabbitMQSettings rabbitMQSettings = Configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();

                    // Config RabbitMq By Masstransit
                    configuration.Host(rabbitMQSettings.Host, "/", h => {
                        h.Username(rabbitMQSettings.Username);
                        h.Password(rabbitMQSettings.Password);
                    });

                    configuration.Message<OrderCheckoutEvent>(x => {
                        x.SetEntityName("Order.Orchestration");
                    });
                    configuration.Send<OrderCheckoutEvent>(x => { 
                        x.UseRoutingKeyFormatter(context => "16042002"); 
                    });

                    configuration.Publish<OrderCheckoutEvent>(x => x.ExchangeType = ExchangeType.Direct);


                    // Consume

                    configuration.ReceiveEndpoint("Order-Checkout", e => {
                        e.ConfigureConsumer<OrderCheckoutConsumer>(context);
                        
                        e.Bind("Market.Checkout",x => {
                            x.AutoDelete = false;
                            x.Durable = true;
                            x.ExchangeType = ExchangeType.Direct;
                            x.RoutingKey = "15122001";
                            
                        });
                    });
                });
            });
            services.AddMassTransitHostedService();

        }
    }
}

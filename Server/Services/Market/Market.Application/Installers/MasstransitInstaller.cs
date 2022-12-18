using System.Reflection;
using EventBus.Messages.Events;
using Market.Application.Consumers;
using Market.Infra.Masstransit;
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

                    var Configuration = context.GetService<IConfiguration>();

                    var rabbitMQSettings = Configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();

                    // Config RabbitMq By Masstransit
                    configuration.Host(rabbitMQSettings.Host, "/", h => {
                        h.Username(rabbitMQSettings.Username);
                        h.Password(rabbitMQSettings.Password);
                    });

                    MasstransitPublish masstransitPublish = new();
                    masstransitPublish.ConfigRabbitMq(context, configuration);

                    MasstransitConsumer masstransitConsumer = new();
                    masstransitConsumer.ConfigRabbitMq(context, configuration);
                     
                });
            });
            services.AddMassTransitHostedService();

        }
    }
}

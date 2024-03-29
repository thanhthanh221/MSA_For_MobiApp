using System.Reflection;
using Application.Common.Extensions;
using Application.Common.Settings;
using MassTransit;

namespace Market.Product.Api.Installers
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
                });
            });
        }
    }
}
using System.Reflection;
using Application.Common.Settings;
using GreenPipes;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.MassTransit
{
    public static class MasstransitExtension
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(configure => {
                // Tất cả các file trong đó
                configure.AddConsumers(Assembly.GetEntryAssembly());

                // Config Time To live
                MessageDataDefaults.TimeToLive = TimeSpan.FromDays(7);
    
                // cài đặt khi sử dung rbmq
                configure.UsingRabbitMq((context, configuration) => {
                    IConfiguration Configuration = context.GetService<IConfiguration>();

                    ServiceSettings serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

                    RabbitMQSettings rabbitMQSettings =  Configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();

                    // Config RabbitMq By Masstransit
                    configuration.Host(rabbitMQSettings.Host, rabbitMQSettings.Virtual_host, h => {
                        h.Username(rabbitMQSettings.Username);
                        h.Password(rabbitMQSettings.Password);
                    });

                    configuration.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));

                    // Thử lại
                    configuration.UseMessageRetry(entryConfig => {
                        entryConfig.Interval(3, TimeSpan.FromSeconds(3));
                    });
                });
            });

            services.AddMassTransitHostedService();
            return services;
        }

    }
}

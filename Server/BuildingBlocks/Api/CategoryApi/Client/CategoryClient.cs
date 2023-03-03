using CategoryApi.Models;
using CategoryApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Timeout;

namespace CategoryApi.Client
{
    public static class CategoryClient
    {
        private const string Uris = "https://localhost:7027"; // Call Api qua ApiGateWay
        public static IServiceCollection InstallCategoryClient(this IServiceCollection services)
        {
            Random jitterer = new();

            services.AddHttpClient("CategoryClient", client => {
                client.BaseAddress = new Uri(Uris);
            })
            .AddTransientHttpErrorPolicy(builder =>
                builder.Or<TimeoutRejectedException>().WaitAndRetryAsync(5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                        + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)),
                    onRetry: (outcome, timespan, retryAttempt) => {
                        var serviceProvider = services.BuildServiceProvider();

                        // Thông báo dòng cảnh báo
                        serviceProvider.GetService<ILogger<CategoryClientRes>>()
                            .LogWarning("Delay {Time} thu lai {retryAttempt} Khi call Api tới Category Service", timespan.TotalSeconds, retryAttempt);
                    }
                )
            )
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(1));
            services.AddScoped<ICategoryCallApi, CategoryCallApi>();

            return services;
        }
    }
}
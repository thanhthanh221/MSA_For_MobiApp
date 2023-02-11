using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Installer
{
    public static class SystemInstaller
    {
        public static IServiceCollection AddSystemBase(this IServiceCollection services)
        {
            services.AddControllers(option => {
                option.SuppressAsyncSuffixInActionNames = false; //Phương thức xóa bỏ hậu tố bất đồng bộ (Async)
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors();
            services.AddHttpClient();
            return services;
        }

    }
}
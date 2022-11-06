using System.Reflection;
using MediatR;

namespace Order.Application.Api.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
            services.AddControllers(option => {
                option.SuppressAsyncSuffixInActionNames = false; //Phương thức xóa bỏ hậu tố bất đồng bộ (Async)
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}

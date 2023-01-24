using Application.Common.Extensions;
using Identity.Domain.IdentityConfig;
using Identity.Domain.Interfaces;
using Identity.Domain.Model;
using Identity.Infra.ServiceContext;
using Identity.Infra.UnitOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Installers
{
    public class DataBaseInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Đăng ký các dịch vụ của Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddUserManager<UserManager>()
                .AddEntityFrameworkStores<IdentityServiceContext>()
                .AddDefaultTokenProviders();
            services.AddDbContext<IdentityServiceContext>(options => {
                string sqlConfig = configuration.GetConnectionString("Context");
                options.UseSqlServer(sqlConfig);
            });
        }
    }
}
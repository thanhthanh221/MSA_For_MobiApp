using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Application.Common.Installer
{
    public static class SystemInstaller
    {
        public static IServiceCollection AddSystemBase(this IServiceCollection services)
        {
            services.AddControllers(option => {
                option.SuppressAsyncSuffixInActionNames = false; //Phương thức xóa bỏ hậu tố bất đồng bộ (Async)
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Service Api", Version = "v1" });

                OpenApiSecurityScheme securityScheme = new() {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                };
                c.AddSecurityDefinition("Bearer", securityScheme);

                OpenApiSecurityRequirement securityRequirement = new()
                {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    };
                c.AddSecurityRequirement(securityRequirement);
            });
            services.AddCors();
            services.AddHttpClient();
            return services;
        }

    }
}
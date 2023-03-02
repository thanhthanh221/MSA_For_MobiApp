using System.Text;
using Application.Common.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application.Common.Installer
{
    public static class AuthenticationInstaller
    {
        public static IServiceCollection AddAuthenticationInCommon(this IServiceCollection services)
        {
            services.AddAuthentication(o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o => {
                o.SaveToken = true;
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = ApplicationKeyUtils.ValidAudience,
                    ValidIssuer = ApplicationKeyUtils.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApplicationKeyUtils.Key))
                };
            });
            return services;
        }
    }
}
﻿using Microsoft.OpenApi.Models;

namespace Market.Application.Api.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(option => {
                option.SuppressAsyncSuffixInActionNames = false; //Phương thức xóa bỏ hậu tố bất đồng bộ (Async)
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

    }
}
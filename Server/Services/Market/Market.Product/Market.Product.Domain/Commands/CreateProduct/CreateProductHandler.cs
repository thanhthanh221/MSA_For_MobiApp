using System.Net.Http.Json;
using Application.Common.Utils;
using CategoryApi.Models;
using CategoryApi.Services;
using Market.Product.Domain.Interfaces;
using Market.Product.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Product.Domain.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductAggregate>
    {
        private readonly ILogger<CreateProductHandler> logger;
        private readonly IProductManager productManager;
        private readonly ICategoryCallApi categoryCallApi;

        public CreateProductHandler(
            ILogger<CreateProductHandler> logger, IProductManager productManager, ICategoryCallApi categoryCallApi)
        {
            this.logger = logger;
            this.productManager = productManager;
            this.categoryCallApi = categoryCallApi;
        }

        public async Task<ProductAggregate> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            bool checkCategory = true;
            List<CategoryClientRes> categoryClients = new();
            // Gửi thông báo bằng Service Nofitication

            // Cal Api bằng Http Client => thông báo cho người dùng hệ thống có thêm 1 sản phẩm
            foreach (var cateId in command.ListCateId) {
                var cateByCallApi = await categoryCallApi.GetCategoryByIdCallApi(cateId);
                if (cateByCallApi is null) { checkCategory = false; }
                categoryClients.Add(cateByCallApi);
            }
            if (!checkCategory) { return null; } // Nếu danh mục sản phẩm không hợp lệ !!

            // Tạo Product
            var product = await productManager.CreateAsync(command, categoryClients);
            logger.LogInformation("Tạo 1 sản phẩm {ProductId} - {ProductName}", product.Id, product.Name);
            return product;
        }
    }
}
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

        public CreateProductHandler(IProductManager productManager, ILogger<CreateProductHandler> logger)
        {
            this.logger = logger;
            this.productManager = productManager;
        }

        public async Task<ProductAggregate> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Tạo Product
            var product = await productManager.CreateAsync(command);
            if (product is null) {
                logger.LogWarning("Không tạo được sản phẩm");
                return null;
            }
            
            // Gửi thông báo bằng Service Nofitication
            try {
                // Cal Api bằng Http Client => thông báo cho người dùng hệ thống có thêm 1 sản phẩm
            }
            catch (Exception) {
                logger.LogWarning("Không call Api được tới Service Nofitication");
            }
            logger.LogInformation("Tạo 1 sản phẩm {ProductId} - {ProductName}",product.Id, product.Name);
            return product;
        }
    }
}
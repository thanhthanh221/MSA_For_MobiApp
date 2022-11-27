using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Domain.Commands.UpdatePriceProduct
{
    public class UpdatePriceProductHandler : IRequestHandler<UpdatePriceProductCommand, bool>
    {
        private readonly IAsyncRepository<Product> productRepositoty;
        private readonly ILogger<UpdatePriceProductHandler> logger;
        public UpdatePriceProductHandler(
            IAsyncRepository<Product> productRepositoty, 
            ILogger<UpdatePriceProductHandler> logger)
        {
            this.productRepositoty = productRepositoty;
            this.logger = logger;
        }
        public async Task<bool> Handle(UpdatePriceProductCommand command, CancellationToken cancellationToken)
        {
            var validationResult = new UpdatePriceProductValidation().Validate(command);

            if (!validationResult.IsValid) {
                return false;
            }
            var Product = await productRepositoty.GetByIdAsync(command.ProductId);
            if(Product is null)
            {
                return false;
            }
            var checkUpdatePriceProduct = Product.UpdatePriceProduct(command.NewPrice);
            if(!checkUpdatePriceProduct)
            {
                return false;
            }

            logger.LogInformation(@$"Update Price Product : {command.ProductId}
                                New Price : {Product.Price}");

            await productRepositoty.UpdateAsync(Product);
            return true;
        }
    }
}
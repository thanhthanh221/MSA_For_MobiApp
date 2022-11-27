using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Domain.Commands.UpdateQuantityProduct
{
    public class UpdateQuantityProductHandler : IRequestHandler<UpdateQuantityProductCommand, bool>
    {
        private readonly IAsyncRepository<Product> productRepositoty;
        private readonly ILogger<UpdateQuantityProductHandler> logger;
        public UpdateQuantityProductHandler(
            IAsyncRepository<Product> productRepositoty, 
            ILogger<UpdateQuantityProductHandler> logger)
        {
            this.productRepositoty = productRepositoty;
            this.logger = logger;
        }

        public async Task<bool> Handle(UpdateQuantityProductCommand command, CancellationToken cancellationToken)
        {
            var validationResult = new UpdateQuantityProductValidation().Validate(command);

            if (!validationResult.IsValid) {
                return false;
            }
            var Product = await productRepositoty.GetByIdAsync(command.ProductId);
            if(Product is null)
            {
                return false;
            }
            Product.UpdateQuantityProduct(command.NewQuantity);
            await productRepositoty.UpdateAsync(Product);

            logger.LogInformation(@$"     
                                Update Product: {Product.Id}  
                                new Quantity: {Product.Quantity} 
                                time : {DateTime.Now}");
            return true;
        }
    }
}
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Domain.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IAsyncRepository<Product> productRepository;
        private readonly ILogger<DeleteProductHandler> logger;

        public DeleteProductHandler(
            IAsyncRepository<Product> productRepository,
            ILogger<DeleteProductHandler> logger)
        {
            this.productRepository = productRepository;
            this.logger = logger;
        }

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var validationResult = new DeleteProductValidation().Validate(command);

            if (!validationResult.IsValid) {
                return false;
            }
            var Product = await productRepository.GetByIdAsync(command.ProductId);
            if(Product is null || command.UserId != Product.UserId)
            {
                return false;
            }
            await productRepository.RemoveAsync(Product.Id);
            logger.LogInformation(@$"Delete Product : {Product.Id} 
                                    Time : {DateTime.Now}");
            return true;
        }
    }
}
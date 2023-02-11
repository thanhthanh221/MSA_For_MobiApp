using Application.Common.Data;
using Application.Common.Repository;
using CatchingRedis.Services;
using Market.Product.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Product.Domain.Commands.RemoveProduct
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IRepository<ProductAggregate> productRepository;
        private readonly ILogger<RemoveProductHandler> logger;
        private readonly IReposeCacheService cacheService;

        public RemoveProductHandler(
            IRepository<ProductAggregate> productRepository, ILogger<RemoveProductHandler> logger, IReposeCacheService cacheService)
        {
            this.productRepository = productRepository;
            this.logger = logger;
            this.cacheService = cacheService;
        }

        public async Task<bool> Handle(RemoveProductCommand command, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(command.ProductId);
            if (product is null) { return false; }
            
            // Xóa dữ liệu trong cache
            await cacheService.RemoveCacheAsync(RedisCachePattern.ProductPattern, command.ProductId);

            // Xóa dữ liệu trong Db
            await productRepository.RemoveAsync(command.ProductId);

            logger.LogInformation("Xóa Product in cache - Db {ProductId} - {ProductName}", product.Id, product.Name);
            return true;
        }
    }
}
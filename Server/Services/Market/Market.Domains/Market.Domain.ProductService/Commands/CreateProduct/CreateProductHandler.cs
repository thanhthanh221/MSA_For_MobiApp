using Application.Common.Repository;
using EventBus.Messages.Events;
using Market.Domain.ProductService.Model;
using Market.Domain.ProductService.Services;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Market.Domain.ProductService.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductAggregate>
    {
        private readonly IRepository<ProductAggregate> productRepository;
        private readonly ILogger<CreateProductHandler> logger;
        private readonly IProductService productService;
        private readonly IMediator mediator;
        private readonly IPublishEndpoint publishEndpoint;

        public CreateProductHandler(
            IRepository<ProductAggregate> productRepository, ILogger<CreateProductHandler> logger, IProductService productService, IMediator mediator, IPublishEndpoint publishEndpoint)
        {
            this.productRepository = productRepository;
            this.logger = logger;
            this.productService = productService;
            this.mediator = mediator;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task<ProductAggregate> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await productService.AddProduct(command);
            await productRepository.CreateAsync(product);
            CreateProductEvent createProductEvent = new(command.UserId, command.CategoriesId);
            await publishEndpoint.Publish(createProductEvent, cancellationToken);
            return product;
        }
    }
}
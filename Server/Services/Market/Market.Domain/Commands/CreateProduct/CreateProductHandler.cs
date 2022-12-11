using Application.Common.Helper;
using Market.Domain.Events.CreateProduct;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Market.Domain.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IAsyncRepository<Product> productRepository;
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly ILogger<CreateProductHandler> logger;
        private readonly IMediator mediator;

        public CreateProductHandler(IAsyncRepository<Product> productRepository,
                                    IAsyncRepository<Category> categoryRepository,
                                    ILogger<CreateProductHandler> logger,
                                    IMediator mediator)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.logger = logger;
            this.mediator = mediator;
        }

        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var validationResult = new CreateProductCommandValidation().Validate(command);

            if (!validationResult.IsValid) {
                return null;
            }

            var allProduct = await productRepository.GetAllAsync();
            var checkProduct = allProduct.Any(p => p.Name.ToLower().Equals(command.Name.Trim().ToLower()));

            if (checkProduct) {
                logger.LogWarning($"product already exists : {command.Name} ");
                return null;
            }
            string imageToString = UploadFileHelper.IFormFileToBase64ImageOfVideo(command.Image);

            List<Category> categories = new();
            foreach (var cateId in command.CategoriesId) {
                var category = await categoryRepository.GetByIdAsync(cateId);
                if (category is null) {
                    logger.LogInformation(message: $@"Category Id: {cateId} does not exist
                                                    Time : {DateTime.Now}");
                    return null;
                }
                categories.Add(category);
            }

            HashSet<TypeProduct> typeProducts = new();

            foreach (var p in command.TypeProducts) {
                var typeProduct = JsonConvert.DeserializeObject<TypeProduct>(p);
                typeProducts.Add(typeProduct);
            }

            Product product = new(
                command.Name.Trim(),
                command.Calo,
                command.Descretion.Trim(),
                command.TypeName.Trim(),
                typeProducts,
                command.UserId,
                command.UserName.Trim(),
                imageToString,
                categories,
                new TimeSpan(command.TimeOrder.Day, command.TimeOrder.Hours, command.TimeOrder.Minute, 0)
            );

            await productRepository.CreateAsync(product);

            // Create Event

            CreateProductEvent createProductEvent = new(product);

            await mediator.Publish(createProductEvent, cancellationToken);

            logger.LogInformation(message: $"Create Product {product.Id}");

            return product;
        }
    }
}
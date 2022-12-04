using Application.Common.Helper;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Domain.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly IMediator mediator;
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly ILogger<CreateCategoryHandler> logger;

        public CreateCategoryHandler(
            IMediator mediator, IAsyncRepository<Category> categoryRepository, ILogger<CreateCategoryHandler> logger)
        {
            this.mediator = mediator;
            this.categoryRepository = categoryRepository;
            this.logger = logger;
        }

        public async Task<Category> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var validationResult = new CreateCategoryCommandValidation().Validate(command);

            if (!validationResult.IsValid) {
                return null;
            }

            var ListCategory = await categoryRepository.GetAllAsync();

            if(ListCategory.Any(c => c.Name.ToLower().Equals(command.Name.ToLower().Trim())))
            {
                logger.LogWarning($"Da ton tai danh mục tren Time : {DateTime.Now}");
                return null;
            }
            // Chuyển ảnh sản phẩn thành String
            string imageCategory = UploadFileHelper.IFormFileToBase64ImageOfVideo(command.Image);

            Category category = new(command.Name.Trim(), imageCategory);

            HashSet<Category> categories = new();

            if (command.ParentId != null) {
                foreach (var cateId in command.ParentId) {
                    var parentCate = await categoryRepository.GetByIdAsync(cateId);

                    if (parentCate is null) {
                        logger.LogWarning($"Khong ton tai Category vs Id : {cateId} -- Time : {DateTime.Now}");
                        return null;
                    }
                    
                    categories.Add(parentCate);
                }
            }

            category.SetParentCategory(categories);

            await categoryRepository.CreateAsync(category);

            logger.LogInformation($"CreateCategory Id : {category.Id} -- Time : {DateTime.Now}");

            return category;
        }
    }
}

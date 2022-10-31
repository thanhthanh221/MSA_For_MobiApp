using AutoMapper;
using Market.Application.Dtos;
using Market.Application.Helper;
using Market.Application.Interfaces;
using Market.Domain.Commands.CategoryCommand;
using Market.Domain.Core.Bus;
using Market.Domain.Interface;
using Market.Domain.Model;
using Microsoft.Extensions.Logging;

namespace Market.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;
        private readonly IMediatorHandler bus;
        private readonly ILogger<CategoryService> logger;

        public CategoryService(IAsyncRepository<Category> categoryRepository,
                               IMapper mapper,
                               IMediatorHandler bus,
                               ILogger<CategoryService> logger)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.bus = bus;
            this.logger = logger;
        }

        public async Task CreateAsync(CategoryWriteDto writeDto)
        {
            CategoryCreateCommand categoryCreateCommand = mapper.Map<CategoryCreateCommand>(writeDto);
            categoryCreateCommand.image = await UploadFileHelper.SaveImage(writeDto.image, "ImageCategory");

            await bus.SendCommand(categoryCreateCommand);
        }

        public async Task DeleteAsync(Guid Id)
        {
            CategoryDeleteCommand categoryDeleteCommand = new CategoryDeleteCommand(Id);

            // Bus to Command Handle
            await bus.SendCommand(categoryDeleteCommand);
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            // List Category Find
            IEnumerable<Category> listCategory = await categoryRepository.GetAllAsync();

            //Mapper to Dto
            IEnumerable<CategoryReadDto> listCategoryDto = mapper.Map<IEnumerable<CategoryReadDto>>(listCategory);
            return listCategoryDto;
        }

        public async Task<CategoryReadDto> GetByIdAsync(Guid Id)
        {
            Category category = await categoryRepository.GetByIdAsync(Id);

            CategoryReadDto categoryReadDto = mapper.Map<CategoryReadDto>(category);
            
            return categoryReadDto is null ? null : categoryReadDto;
        }

        public async Task UpdateAsync(CategoryWriteDto writeDto, Guid Id)
        {
            Category category = await categoryRepository.GetByIdAsync(Id);

            if(category != null)
            {
                CategoryUpdateCommand categoryUpdateCommand = mapper.Map<CategoryUpdateCommand>(writeDto);

                categoryUpdateCommand.Id = category.Id;
                categoryUpdateCommand.CreateAt = category.CreateAt;
                categoryUpdateCommand.CreateBy = category.CreateBy;
                categoryUpdateCommand.image = await UploadFileHelper.SaveImage(writeDto.image, "ImageCategory");

                // Bus Send Data
                await bus.SendCommand(categoryUpdateCommand);
            }
        }
    }
}

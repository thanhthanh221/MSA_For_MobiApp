using AutoMapper;
using Market.Application.Dtos;
using Market.Application.Helper;
using Market.Application.Interfaces;
using Market.Domain.Commands.ProductCommand;
using Market.Domain.Core.Bus;
using Market.Domain.Interface;
using Market.Domain.Model;
using Microsoft.Extensions.Logging;

namespace Market.Application.Services
{
    public class ProductServies : IProductServices
    {
        private readonly IAsyncRepository<Product> productRepository;
        private readonly IMapper mapper;
        private readonly IMediatorHandler bus;
        private readonly ILogger<ProductServies> logger;

        public ProductServies(IAsyncRepository<Product> productRepository,
                              IMediatorHandler bus,
                              IMapper mapper,
                              ILogger<ProductServies> logger)
        {
            this.productRepository = productRepository;
            this.bus = bus;
            this.mapper = mapper;
            this.logger = logger;
        }

        //Querry

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            IEnumerable<Product> AllProduct = await productRepository.GetAllAsync();

            //Mapper             
            IEnumerable<ProductReadDto> productReadDtos = mapper.Map<IEnumerable<ProductReadDto>>(AllProduct);

            return productReadDtos;
        }

        public async Task<ProductReadDto> GetByIdAsync(Guid Id)
        {
            //Create Product To Dto
            Product product = await productRepository.GetByIdAsync(Id);

            // Return Product Map To Dto
            return mapper.Map<ProductReadDto>(product);
        }

        // Command

        // Service Bus To Domain Command Handle
        public async Task CreateAsync(ProductWriteDto productDto)
        {

            //Mapper WriteDto => Command

            ProductCreateCommand registerProduct = mapper.Map<ProductCreateCommand>(productDto);
            registerProduct.Image = await UploadFileHelper.SaveImage(productDto.Image, "ImageProduct");

            // Bus To Domain Layer
            await bus.SendCommand(registerProduct);
        }

        public async Task DeleteAsync(Guid Id)
        {
            ProductDeleteCommand deleteProductCommand = new ProductDeleteCommand(Id);

            // Bus to Command Handle
            await bus.SendCommand(deleteProductCommand);
        }

        // Update Product Service
        public async Task UpdateAsync(ProductWriteDto productDto, Guid Id)
        {
            Product product = await productRepository.GetByIdAsync(Id);
            if(product != null)
            {
                ProductUpdateCommand updateProductCommmand = mapper.Map<ProductUpdateCommand>(productDto);

                // Upload Prop Null-IsEn
                updateProductCommmand.Id = Id;
                updateProductCommmand.CreateBy = product.CreateBy;
                updateProductCommmand.CreateAt = product.CreateAt;
                updateProductCommmand.Image = await UploadFileHelper.SaveImage(productDto.Image, "ImageProduct");

                // Bus Send Data
                await bus.SendCommand(updateProductCommmand); 
            }
        }
    }
}

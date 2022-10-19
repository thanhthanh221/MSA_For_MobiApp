using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Dtos;
using Market.Application.Helper;
using Market.Application.Interfaces;
using Market.Application.Mapper;
using Market.Domain.Commands;
using Market.Domain.Core.Bus;
using Market.Domain.Interface;
using Market.Domain.Model;

namespace Market.Application.Services
{
    public class ProductServies : IProductServices
    {
        private readonly IAsyncProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IMediatorHandler bus;

        public ProductServies(IAsyncProductRepository productRepository, IMediatorHandler bus, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.bus = bus;
            this.mapper = mapper;
        }

        // Service Bus To Domain Command Handle
        public async Task RegisterAsync(ProductWriteDto productDto)
        {

            //Mapper WriteDto => Command

            CreateNewProductCommand RegisterProduct = mapper.Map<CreateNewProductCommand>(productDto);

            // Bus To Domain Layer
            await bus.SendCommand(RegisterProduct);
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            IEnumerable<Product> AllProduct = await productRepository.GetAllAsync();

            //Mapper             
            IEnumerable<ProductReadDto> productReadDtos = mapper.Map<IEnumerable<ProductReadDto>>(AllProduct);

            return productReadDtos;
        }

        public async Task<ProductReadDto> GetById(Guid Id)
        {
            //Create Product To Dto
            Product product = await productRepository.GetByIdAsync(Id);

            // Return Product Map To Dto
            return mapper.Map<ProductReadDto>(product);
        }

        public async Task DeleteAsync(Guid Id)
        {
            await productRepository.RemoveAsync(Id);
        }

        // Update Product Service
        public async Task UpdateAsync(ProductWriteDto productDto, Guid Id)
        {
            Product product = await productRepository.GetByIdAsync(Id);
            if(product != null)
            {
                UpdateProductCommand updateProductCommmand = mapper.Map<UpdateProductCommand>(productDto);
                updateProductCommmand.Id = Id;
                await bus.SendCommand(updateProductCommmand); 
            }
        }
    }
}

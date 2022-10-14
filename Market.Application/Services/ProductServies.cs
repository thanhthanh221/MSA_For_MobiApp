using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Market.Application.Dtos;
using Market.Application.Interfaces;
using Market.Domain.Commands;
using Market.Domain.Core.Bus;
using Market.Domain.Interface;
using Market.Domain.Model;

namespace Market.Application.Services
{
    public class ProductServies : IProductServices
    {
        private readonly IAsyncProductRepository productRepository;
        private readonly IMediatorHandler bus;

        public ProductServies(IAsyncProductRepository productRepository, IMediatorHandler bus)
        {
            this.productRepository = productRepository;
            this.bus = bus;
        }

        public async Task RegisterAsync(ProductReadDto productDto)
        {
            CreateNewProductCommand RegisterProduct = new CreateNewProductCommand(
                Guid.NewGuid(),
                productDto.Name,
                productDto.Price,
                productDto.Calo,
                productDto.Descretion,
                productDto.Alias,
                productDto.Warranty,
                productDto.PromotionPrice,
                productDto.Quantity,
                productDto.OriginalPrice,
                DateTime.Now,
                productDto.createBy
            );
            await bus.SendCommand(RegisterProduct);
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            IEnumerable<Product> AllProduct = await productRepository.GetAllAsync();

            return null;
        }

        public Task<Product> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductReadDto productDto, Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

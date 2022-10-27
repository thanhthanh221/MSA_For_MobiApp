using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Market.Application.Dtos;
using Market.Application.Interfaces;
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

        public Task CreateAsync(ProductWriteDto writeDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            // List Category Find
            IEnumerable<Category> listCategory =await categoryRepository.GetAllAsync();

            return null;
        }

        public Task<CategoryReadDto> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductWriteDto writeDto, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

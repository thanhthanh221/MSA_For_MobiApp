using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Market.Domain.Commands.CategoryCommand;
using Market.Domain.Core.Bus;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Domain.CommandHandlers
{
    public class CategoryCommandHandlers :
        CommandHandlers,
        IRequestHandler<CategoryCreateCommand, bool>,
        IRequestHandler<CategoryDeleteCommand, bool>,
        IRequestHandler<CategoryUpdateCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMediatorHandler bus;
        private readonly ILogger<CategoryCommandHandlers> logger;

        public CategoryCommandHandlers(IMapper mapper,
                                       IAsyncRepository<Category> categoryRepository,
                                       IMediatorHandler bus,
                                       ILogger<CategoryCommandHandlers> logger)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.bus = bus;
            this.logger = logger;
        }

        public Task<bool> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) {
                logger.LogInformation("Tạo mới danh mục bị lỗi {time}", DateTime.Now);
                Task.FromResult(false);
            }
            // Mapper command => Entity
            Category category = mapper.Map<Category>(request);

            Task taskCategory = categoryRepository.CreateAsync(category);

            return Task.FromResult(true);
        }

        public Task<bool> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid())
            {
                logger.LogInformation("Không xóa được danh mục bị lỗi {time}", DateTime.Now);
                Task.FromResult(false);
            }

            categoryRepository.RemoveAsync(request.Id);
            return Task.FromResult(true);

        }

        public Task<bool> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid())
            {
                logger.LogInformation("Chỉnh sửa danh mục bị lỗi {time}", DateTime.Now);
                Task.FromResult(false);
            }
            // Mapper
            Category category = mapper.Map<Category>(request);
            categoryRepository.UpdateAsync(category);

            return Task.FromResult(true);
        }
    }
}

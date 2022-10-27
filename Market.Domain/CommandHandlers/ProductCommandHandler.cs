using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Market.Domain.Commands.ProductCommand;
using Market.Domain.Core.Bus;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;

namespace Market.Domain.CommandHandlers
{
    public class ProductCommandHandler
        : CommandHandlers,
        IRequestHandler<ProductCreateCommand, bool>,
        IRequestHandler<ProductDeleteCommand, bool>,
        IRequestHandler<ProductUpdateCommand, bool>
    {
        private readonly IAsyncProductRepository productRepository;
        private readonly IMediatorHandler bus;
        private readonly IMapper mapper;

        public ProductCommandHandler(IAsyncProductRepository productRepository,
                                     IMediatorHandler bus,
                                     IMapper mapper)
        {
            this.productRepository = productRepository;
            this.bus = bus;
            this.mapper = mapper;
        }

        public Task<bool> Handle(ProductCreateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) {
                return Task.FromResult(false);
            }

            // Tạo sản phẩm mới từ dữ liệu gửi xuống command
            Product product = mapper.Map<Product>(message);
            productRepository.CreateAsync(product);

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            // Dữ liệu đẩy xuống không thỏa mãn điều kiện
            if (request.IsValid()) {
                return Task.FromResult(false);
            }

            // Nếu dữ liệu đẩy xuống là đúng
            productRepository.RemoveAsync(request.Id);
            return Task.FromResult(true);
        }

        //Update
        public Task<bool> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) {
                return Task.FromResult(false);
            }

            // Update thông tin sản phẩm
            Product product = mapper.Map<Product>(request);
            productRepository.UpdateAsync(product);
            return Task.FromResult(true);
        }
    }
}

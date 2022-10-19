using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Commands;
using Market.Domain.Interface;
using Market.Domain.Model;
using MediatR;

namespace Market.Domain.CommandHandlers
{
    public class ProductCommandHandler
        : CommandHandlers,
        IRequestHandler<CreateNewProductCommand, bool>,
        IRequestHandler<DeleteProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IAsyncProductRepository productRepository;

        public ProductCommandHandler(IAsyncProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<bool> Handle(CreateNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) {
                return Task.FromResult(false);
            }

            // Tạo sản phẩm mới từ dữ liệu gửi xuống command
            Product product = new Product(
                message.Id,
                message.Name,
                message.Price,
                message.Image,
                message.Calo,
                message.Descretion,
                message.Alias,
                message.Warranty,
                message.PromotionPrice,
                message.Quantity,
                message.OriginalPrice,
                message.CreateAt,
                message.CreateBy
            );
            productRepository.CreateAsync(product);

            return Task.FromResult(true);
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // Dữ liệu đẩy xuống không thỏa mãn điều kiện
            if (request.IsValid()) {
                return Task.FromResult(false);
            }

            // Nếu dữ liệu đẩy xuống là đúng
            productRepository.RemoveAsync(request.Id);
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid())
            {
                return Task.FromResult(false);
            }

            // Update thông tin sản phẩm
            Product product = new Product (
                request.Id,
                request.Name,
                request.Price,
                request.Image,
                request.Calo,
                request.Descretion,
                request.Alias,
                request.Warranty,
                request.PromotionPrice,
                request.Quantity,
                request.OriginalPrice,
                request.CreateAt,
                request.CreateBy,
                request.UpdateAt,
                request.UpdateBy
            );
            productRepository.UpdateAsync(product);
            return Task.FromResult(true);
        }
    }
}

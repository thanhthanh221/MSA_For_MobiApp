using Application.Common.Repository;
using Market.Product.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using UserApi.Data;
using UserApi.Services;

namespace Market.Product.Domain.Commands.UserFavouriteProduct
{
    public class UserFavouriteProductHandler : IRequestHandler<UserFavouriteProductCommand>
    {
        private readonly IUserClientService userClient;
        private readonly IRepository<ProductAggregate> productRepository;

        public UserFavouriteProductHandler(
            IUserClientService userClient, IRepository<ProductAggregate> productRepository)
        {
            this.userClient = userClient;
            this.productRepository = productRepository;
        }

        public async Task<Unit> Handle(UserFavouriteProductCommand request, CancellationToken cancellationToken)
        {
            // Kiểm tra xem người dùng có tồn tại không 
            var userData = await userClient.GetUserCallApiById(request.UserId, request.JsonWebToken);
            if (userData.UserName is null) { return Unit.Value; }

            var product = await productRepository.GetByIdAsync(request.ProductId);
            if (product is null) { return Unit.Value; }

            // Kiểm tra đã có chưa
            var usersFavoProduct = product.UserLikeProduct;
            if (usersFavoProduct.Contains(request.UserId)) { usersFavoProduct.Remove(request.UserId); }
            else { usersFavoProduct.Add(request.UserId); }

            await productRepository.UpdateAsync(product);
            return Unit.Value;
        }
    }
}
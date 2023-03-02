using MediatR;

namespace Market.Product.Domain.Commands.UserFavouriteProduct
{
    public class UserFavouriteProductCommand : IRequest<Unit>
    {
        public UserFavouriteProductCommand()
        {
        }

        public UserFavouriteProductCommand(Guid userId, Guid productId, string jsonWebToken)
        {
            UserId = userId;
            ProductId = productId;
            JsonWebToken = jsonWebToken;
        }

        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string JsonWebToken { get; set; }
    }
}
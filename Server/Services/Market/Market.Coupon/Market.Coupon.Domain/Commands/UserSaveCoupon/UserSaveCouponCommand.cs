using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Market.Coupon.Domain.Commands.UserSaveCoupon
{
    public class UserSaveCouponCommand : IRequest<UserSaveCouponReturn>
    {
        public UserSaveCouponCommand()
        {
        }

        public UserSaveCouponCommand(Guid userId, Guid couponId, string jsonWebToken)
        {
            UserId = userId;
            CouponId = couponId;
            JsonWebToken = jsonWebToken;
        }

        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid CouponId { get; set; }
        [Required]
        public string JsonWebToken { get; set; }
    }
}
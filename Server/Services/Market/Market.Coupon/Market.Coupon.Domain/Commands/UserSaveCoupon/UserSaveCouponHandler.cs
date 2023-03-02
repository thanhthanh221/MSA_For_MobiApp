using Application.Common.Repository;
using Market.Coupon.Domain.Events.UpdateCache;
using Market.Coupon.Domain.Model;
using MediatR;
using UserApi.Services;

namespace Market.Coupon.Domain.Commands.UserSaveCoupon
{
    public class UserSaveCouponHandler : IRequestHandler<UserSaveCouponCommand, UserSaveCouponReturn>
    {
        private readonly IRepository<CouponAggregate> couponRepository;
        private readonly IUserClientService userClient;
        private readonly IMediator mediator;

        public UserSaveCouponHandler(
            IRepository<CouponAggregate> couponRepository, IUserClientService userClient, IMediator mediator)
        {
            this.couponRepository = couponRepository;
            this.userClient = userClient;
            this.mediator = mediator;
        }

        public async Task<UserSaveCouponReturn> Handle(UserSaveCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await couponRepository.GetByIdAsync(request.CouponId);
            // Kiểm tra người dùng có tồn tại không
            var userData = await userClient.GetUserCallApiById(request.UserId, request.JsonWebToken);
            if (userData.UserName is null) { return new UserSaveCouponReturn(false, "Không tồn tại người dùng trên"); }

            if (coupon is null || coupon.Quantity == 0) {
                return new UserSaveCouponReturn(false, "Mã giảm giá đã hết");
            }
            if (coupon.UserId.Contains(request.UserId)) {
                return new UserSaveCouponReturn(false, "Bạn đã sở hữu mã giảm giá này rồi !");
            }

            if (coupon.UserId.Contains(request.UserId)) {
                coupon.SetQuantityCoupon(coupon.Quantity - 1);
                coupon.UserId.Remove(request.UserId);
            }
            else { // Nếu người dùng đã sở hữu coupon rồi
                coupon.SetQuantityCoupon(coupon.Quantity + 1);
                coupon.UserId.Add(request.UserId);
            }
            // Update lên Db và Cache
            await couponRepository.UpdateAsync(coupon);
            await mediator.Publish(new UpdateCacheEvent(), cancellationToken);

            return new UserSaveCouponReturn(true, "Thêm mã thành công !");

        }
    }
}
using Market.Domain.CouponService.Commands;
using Market.Domain.CouponService.Model;

namespace Market.Domain.CouponService.Service
{
    public interface ICouponService
    {
        Task<CouponAggregate> GetCouponById(Guid CouponId);
        Task<List<CouponAggregate>> GetAllCoupon();
        Task<CouponAggregate> CreateCoupon(CreateCouponCommand createCoupon);
        Task UserSaveCoupon(UserSaveCouponCommand userSaveCoupon);
    }
}

using Market.Coupon.Domain.Model;
using MediatR;

namespace Market.Coupon.Domain.Query.FindCouponById
{
    public class FindCouponByIdQuery : IRequest<CouponAggregate>
    {
        public FindCouponByIdQuery(Guid couponId)
        {
            CouponId = couponId;
        }
        public Guid CouponId { get; set; }
    }
}
using Market.Coupon.Domain.Model;
using MediatR;

namespace Market.Coupon.Domain.Query.FilterCouponByUserId
{
    public class FindCouponByUserIdQuery : IRequest<List<CouponAggregate>>
    {
        public FindCouponByUserIdQuery()
        {
        }

        public FindCouponByUserIdQuery(Guid userId, int page, int pageSize)
        {
            UserId = userId;
            Page = page;
            PageSize = pageSize;
        }

        public Guid UserId {get; set;}
        public int Page {get; set;}
        public int PageSize {get; set;}
    }
}
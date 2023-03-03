using Market.Coupon.Domain.Model;
using MediatR;

namespace Market.Coupon.Domain.Query.FilterAllCoupon
{
    public class FilterAllCouponQuery : IRequest<List<CouponAggregate>>
    {
        public FilterAllCouponQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
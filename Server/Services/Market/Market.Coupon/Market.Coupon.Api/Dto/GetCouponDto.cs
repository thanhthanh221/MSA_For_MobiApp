using Market.Coupon.Domain.Model;

namespace Market.Coupon.Api.Dto
{
    public class GetCouponDto
    {
        public Guid CouponId { get; private set; }
        public string Name { get; private set; }
        public List<string> Descretion { get; private set; }
        public string Value { get; private set; }
        public DateTime Expired { get; private set; }

        public static GetCouponDto ConverEntityToDto(CouponAggregate couponAggregate)
        {
            return new GetCouponDto() {
                CouponId = couponAggregate.Id,
                Name = couponAggregate.Name,
                Descretion = couponAggregate.Description,
                Value = couponAggregate.Value,
                Expired = couponAggregate.Expired
            };
        }
    }
}
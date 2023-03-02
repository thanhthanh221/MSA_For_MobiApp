using Market.Coupon.Domain.Model;

namespace Market.Coupon.Api.Dto
{
    public class GetAllCouponDto
    {
        public GetAllCouponDto()
        {
        }

        public GetAllCouponDto(Guid id, string name, string value, int quantity, DateTime expired)
        {
            Id = id;
            Name = name;
            Value = value;
            Quantity = quantity;
            Expired = expired;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
        public int Quantity { get; private set; }
        public DateTime Expired { get; private set; }

        public static List<GetAllCouponDto> ConverEntityToDto(List<CouponAggregate> coupons)
        {
            return coupons.Select(c => new GetAllCouponDto(c.Id, c.Name, c.Value, c.Quantity, c.Expired)).ToList();
        }
    }
}
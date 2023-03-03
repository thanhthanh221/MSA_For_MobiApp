using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Market.Coupon.Domain.Model;
using MediatR;

namespace Market.Coupon.Domain.Commands.CreateCoupon
{
    public class CreateCouponCommand : IRequest<CouponAggregate>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<string> Description { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public decimal MinPriceOrder { get; set; }
        [Required]
        public decimal MoneyIsReduced { get; set; }
        public int Quantity { get; set; }
        [Required]
        [Range(1, 31)]
        public int Day { get; set; }
        [Required]
        [Range(1, 12)]
        public int Month { get; set; }
        [Required, Range(2022, int.MaxValue)]
        public int Year { get; set; }
    }
}
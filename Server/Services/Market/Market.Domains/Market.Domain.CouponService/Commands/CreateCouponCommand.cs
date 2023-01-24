using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.CouponService.Commands
{
    public class CreateCouponCommand
    {
        [DataMember]
        [Required]
        public string Name { get; private set; }
        [DataMember]
        [Required]
        public List<string> Description { get; private set; }
        [DataMember]
        [Required]
        public string Value { get; private set; }
        [DataMember]
        [Required]
        public decimal MinPriceOrder { get; private set; }
        [DataMember]
        [Required]
        public decimal MoneyIsReduced { get; private set; }
        [DataMember]
        public int Quantity { get; private set; }
        [DataMember]
        [Required]
        [Range(1, 31)]
        public int Day { get; private set; }
        [DataMember]
        [Required]
        [Range(1, 12)]
        public int Month { get; private set; }
        [DataMember]
        [Required]
        [Range(2022, int.MaxValue)]
        public int Year { get; private set; }
    }
}
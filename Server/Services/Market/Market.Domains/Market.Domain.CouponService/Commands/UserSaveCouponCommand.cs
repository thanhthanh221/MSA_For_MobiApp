using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using MediatR;
namespace Market.Domain.CouponService.Commands
{
    public class UserSaveCouponCommand
    {
        [DataMember]
        [Required]
        public Guid UserId { get; private set; }
        [DataMember]
        [Required]
        public Guid CouponId { get; private set; }
    }
}

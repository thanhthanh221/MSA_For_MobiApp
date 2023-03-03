namespace Market.Coupon.Domain.Commands.UserSaveCoupon
{
    public class UserSaveCouponReturn
    {
        public UserSaveCouponReturn(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
using System.Security.Cryptography;
using System.Text;
using Identity.Domain.Interfaces;
using Identity.Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.IdentityConfig
{
    public class OtpManager : IOtpManager
    {
        public const string secretKey = "BuiVietQuang";
        private readonly UserManager userManager;
        public OtpManager(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public Task<string> GenerateTotpUserAsync(ApplicationUser user)
        {
            var Otp = new Random().Next(1000, 9999).ToString();
            if (user.Otp is null) { user.Otp = new(user) { OtpHash = Otp }; return Task.FromResult(Otp); }
            user.ClearOtp(Otp);
            return Task.FromResult(Otp);
        }
        public async Task<IdentityResult> CheckOtpAsync(ApplicationUser user, string otp)
        {
            // Xem Otp Còn hạn hay không
            var checkTimeOtp = DateTime.UtcNow - user.Otp.DateTimeCreate;
            if (checkTimeOtp.TotalSeconds > 60) {
                IdentityError error = new() { Code = "Hết giời gian", Description = "Otp hết hiệu lực" };
                return IdentityResult.Failed(new IdentityError[] { error });
            }
            if (!user.Otp.OtpHash.Equals(otp)) {
                user.Otp.CountSubmit++;
                IdentityError error = new() { Code = "Sai Mã!", Description = "Nhập sai Otp" };
                await userManager.UpdateAsync(user);
                return IdentityResult.Failed(new IdentityError[] { error });
            }
            user.VerifyOtpTrue();
            return IdentityResult.Success;
        }
    }
}
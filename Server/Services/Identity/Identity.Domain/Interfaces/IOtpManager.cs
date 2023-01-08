using Identity.Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Interfaces
{
    public interface IOtpManager
    {
        Task<string> GenerateTotpUserAsync(ApplicationUser user);
        Task<IdentityResult> CheckOtpAsync(ApplicationUser user, string otp);
    }
}
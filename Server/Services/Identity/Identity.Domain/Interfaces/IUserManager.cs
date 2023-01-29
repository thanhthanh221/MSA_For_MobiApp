using Identity.Domain.Model;
using Identity.Domain.ViewModel.Account;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Domain.Interfaces
{
    public interface IUserManager 
    {
        Task<string> GenerateTotpUserAsync(ApplicationUser user);
        Task<ApplicationUser> FindByPhoneAsync(string Phone);
        Task<SecurityToken> RenderJsonWebToken(ApplicationUser user);
        Task<TokenViewModel> GenerateTokenAsync(ApplicationUser user);
    }
}

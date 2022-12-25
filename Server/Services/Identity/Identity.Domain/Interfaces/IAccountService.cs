using System.IdentityModel.Tokens.Jwt;
using Identity.Domain.ViewModel.Account;

namespace Identity.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<object> LoginAsync(LoginViewModel loginViewModel);
        Task<object> RegisterAsync(RegisterViewModel registerViewModel);
        Task<object> ChangePasswordAsync(ResetPasswordViewModel resetPasswordView);
    }
}

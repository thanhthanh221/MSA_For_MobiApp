using System.Security.Claims;
using Application.Common.Helper;
using Identity.Domain.Interfaces;
using Identity.Domain.Model;
using Identity.Domain.ViewModel.Account;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountService(
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task<object> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = await userManager.FindByEmailAsync(loginViewModel.Email);
            // Trường hợp Email không tồn tại
            if (user is null) { return null; }
            var checkedPassWordUser = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
            // Trường hợp Mật khẩu không chính xác
            if (!checkedPassWordUser) { return null; }
            List<Claim> claims = new();
            // Add Claim 
            var userRoles = await userManager.GetRolesAsync(user);
            userRoles.ToList().ForEach(c => {
                claims.Add(new Claim(ClaimTypes.Role, c));
            });
            claims.Add(new Claim("Id", user.Id.ToString()));
            var token = JwtHelper.GetToken(claims);
            return new { token, user.Id, user.UserName };
        }
        public async Task<object> RegisterAsync(RegisterViewModel registerViewModel)
        {
            var useCheckEmailExists = await userManager.FindByEmailAsync(registerViewModel.Email);
            var useCheckNameExists = await userManager.FindByNameAsync(registerViewModel.UserName);
            // Kiểm tra xem UserName hay Email đã tồn tại chưa
            if (useCheckEmailExists != null || useCheckNameExists != null) { return null; }
            // Tạo mới tài khoản
            ApplicationUser appUser = new() { UserName = registerViewModel.UserName, Email = registerViewModel.Email };
            var result = await userManager.CreateAsync(appUser, registerViewModel.Password);
            // Xem có tạo tài khoản thành công hay không
            if (!result.Succeeded) { return null; }

            List<Claim> claims = new() { new Claim("Id", appUser.Id.ToString()) };
            var token = JwtHelper.GetToken(claims);
            return new { token, appUser.Id, appUser.UserName };
        }

        public async Task<object> ChangePasswordAsync(ResetPasswordViewModel resetPasswordView)
        {
            var user = await userManager.FindByIdAsync(resetPasswordView.UserId.ToString());
            // Kiểm tra xem tìm thấy tài khoản không
            if (user == null) { return null; }
            // Xem người dùng có mật khẩu hay không!
            var hasPassword = await userManager.HasPasswordAsync(user);
            if (!hasPassword) { return new { message = "Tài khoản được tạo bởi dịch vụ ngoài!" }; }
            var result = await userManager.ChangePasswordAsync(user, resetPasswordView.OldPassword, resetPasswordView.Password);
            // Khiểm tra xem đổi mật khẩu thành công không
            if (!result.Succeeded) { return new { message = "Mật khẩu cũ không chính xác!" }; }
            return new { message = "Đổi mật khẩu thành công!" };
        }
    }
}

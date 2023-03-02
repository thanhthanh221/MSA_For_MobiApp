using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Common.Utils;
using Identity.Domain.IdentityConfig;
using Identity.Domain.Interfaces;
using Identity.Domain.Model;
using Identity.Domain.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountService> logger;

        public AccountService(
            UserManager userManager, RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager, ILogger<AccountService> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        public async Task<object> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = await userManager.FindByEmailAsync(loginViewModel.Email);
            // Trường hợp Email không tồn tại
            if (user is null) { return new ApiResponseUtils(false, "Không tồn tại tài khoản"); }
            var checkedPassWordUser = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
            // Trường hợp Mật khẩu không chính xác
            if (!checkedPassWordUser) {
                // Tăng số lần người dùng đăng nhập không chính xác !!
                await userManager.AccessFailedAsync(user);
                return new ResponseClient("Tên tài khoản hoặc mật khẩu không chính xác", 200, false);
            }
            // Xem tài khoản có bị khóa hay không
            var checkLockedOut = await userManager.IsLockedOutAsync(user);
            if (checkLockedOut) { return new ResponseClient("Tài khoản bị khóa", 200, false); }
            // Tạo Token cho User
            var token = await userManager.GenerateTokenAsync(user);
            // Reset số lần người dùng đăng nhập sai !!
            await userManager.ResetAccessFailedCountAsync(user);
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

            var token = await userManager.GenerateTokenAsync(appUser);
            return new { token, appUser.Id, appUser.UserName };
        }
        public async Task<ResponseClient> ExternalLoginService(ExternalLoginViewModel model)
        {
            // Tìm kiếm user Theo dịch vụ ngoài đăng nhập
            var appUser = await userManager.FindByLoginAsync(model.Provider, model.ProviderKey);
            // Đã tồn tại tài khoản đăng nhập với dịch vụ ngoài trên
            if (appUser != null) {
                logger.LogInformation("{Name} đã đăng nhập bằng dịch vụ {Provider}", appUser.UserName, model.Provider);
                var token = await userManager.GenerateTokenAsync(appUser);
                return new(token, 200, true);
            }
            return new("Tạo tài khoản mới!", 302);
        }
        public async Task<ResponseClient> ExternalLoginConfirmationService(ExternalLoginConfirmationViewModel model)
        {
            UserLoginInfo info = new(model.Provider, model.ProviderKey, model.Provider);
            var userExisted = await userManager.FindByLoginAsync(model.Provider, model.ProviderKey);
            // Đã có tài khoản sử dụng dịch vụ ngoài trên
            if (userExisted != null) {
                var token = await userManager.GenerateTokenAsync(userExisted);
                return new(token, 200, true);
            }
            // Tìm Kiếm tài khoản theo Email người dùng nhập
            var userFindByEmail = await userManager.FindByEmailAsync(model.Email);
            if (userFindByEmail != null) {
                // Xem tài khoản này đã liên kết với dịch vụ ngoài này chưa
                var infoUser = await userManager.GetLoginsAsync(userFindByEmail);
                bool checkLoginsUser = false;
                infoUser.ToList().ForEach(i => {
                    if (i.LoginProvider.Equals(model.Provider)) { checkLoginsUser = true; }
                });
                if (checkLoginsUser) { return new($"Tài khoản {userFindByEmail.UserName} Đã liên kết với dịch vụ ngoài {model.Provider}", 400, false); }

                // Tài khoản đã tồn tại -- Liên kết dịch vụ ngoài với Tài khoản đã dùng
                var resultAdd = await userManager.AddLoginAsync(userFindByEmail, info);
                if (resultAdd.Succeeded) {
                    var token = await userManager.GenerateTokenAsync(userFindByEmail);
                    return new(token, 200, true);
                }
                return new("Liết kết thất bại với tài khoản", 400, false);
            }
            ApplicationUser appUser = new() { UserName = model.UserName, Email = model.Email };
            var result = await userManager.CreateAsync(appUser);
            if (!result.Succeeded) { return new("Không tạo được tài khoản", 400, false); }
            await userManager.AddLoginAsync(appUser, info);
            logger.LogInformation("{Name} đã đăng nhập bằng dịch vụ {Provider}", appUser.UserName, model.Provider);
            var tokenCheckTrue = await userManager.GenerateTokenAsync(userFindByEmail);
            return new(tokenCheckTrue, 200, true);
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
        public async Task<ResponseClient> RefreshNewToken(TokenViewModel token)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new();
            var secretKeyBytes = Encoding.UTF8.GetBytes(ApplicationKeyUtils.Key);

            TokenValidationParameters tokenValidateParam = new() {
                //tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,
                //ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false //ko kiểm tra token hết hạn
            };

            try {
                //check 1: AccessToken có đúng định dạng không
                var tokenInVerification = jwtTokenHandler.ValidateToken(token.AccessToken, tokenValidateParam, out var validatedToken);

                //check 2: Check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken) {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result) { return new ResponseClient("Token Không hợp lệ", 200, false); }
                }

                var userToken = await userManager.FindByRefreshTokenAsync(token.RefreshToken);

                return null;
            }
            catch (Exception ex) {
                return new ResponseClient(ex.Message, 500, false);
            }
        }
    }
}

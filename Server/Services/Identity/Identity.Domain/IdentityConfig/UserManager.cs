using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Utils;
using Identity.Domain.Helpers;
using Identity.Domain.Interfaces;
using Identity.Domain.Model;
using Identity.Domain.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Domain.IdentityConfig
{
    public class UserManager : UserManager<ApplicationUser>, IUserManager
    {
        private readonly IUnitOfWork unitOfWork;
        public UserManager(IUserStore<ApplicationUser> store,
                           IOptions<IdentityOptions> optionsAccessor,
                           IPasswordHasher<ApplicationUser> passwordHasher,
                           IEnumerable<IUserValidator<ApplicationUser>> userValidators,
                           IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
                           ILookupNormalizer keyNormalizer,
                           IdentityErrorDescriber errors,
                           IServiceProvider services,
                           ILogger<UserManager<ApplicationUser>> logger,
                           IUnitOfWork unitOfWork) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ApplicationUser> FindByPhoneAsync(string Phone)
        {
            var appUser = await Users.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(Phone));
            return appUser;
        }
        public async Task<ApplicationUser> FindByRefreshTokenAsync(string RefreshToken)
        {
            var appUser = await Users.FirstOrDefaultAsync(u => u.RefreshToken.Token.Equals(RefreshToken));
            return appUser;
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
                await this.UpdateAsync(user);
                return IdentityResult.Failed(new IdentityError[] { error });
            }
            user.VerifyOtpTrue();
            return IdentityResult.Success;
        }
        public async Task<SecurityToken> RenderJsonWebToken(ApplicationUser user)
        {
            // Json Web Token
            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(ApplicationKeyUtils.Key));
            // Role
            var userRoles = await this.GetRolesAsync(user);
            List<Claim> claims = new() {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Id", user.Id.ToString()),
            };
            userRoles.ToList().ForEach(c => {
                claims.Add(new Claim(ClaimTypes.Role, c));
            });
            JwtSecurityToken token = new(
                issuer: ApplicationKeyUtils.ValidIssuer, // Nơi được xác thực bằng JWT
                audience: ApplicationKeyUtils.ValidAudience,
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
        public async Task<TokenViewModel> GenerateTokenAsync(ApplicationUser user)
        {
            var token = await this.RenderJsonWebToken(user);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            var accessToken = jwtSecurityTokenHandler.WriteToken(token);

            var newRefreshToken = TokenHelper.GenerateRefreshToken();
            user.UpdateToken(newRefreshToken, token.Id);
            await unitOfWork.SaveDbAsync();

            return new TokenViewModel(accessToken, newRefreshToken);
        }
    }
}
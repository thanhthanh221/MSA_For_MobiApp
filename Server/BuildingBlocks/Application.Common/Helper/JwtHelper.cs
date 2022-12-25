using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Common.Helper
{
    public static class JwtHelper
    {
        public static string JwtKey { get; private set; } = "BuiVietQuangCheckPass";
        public static string GetToken(List<Claim> authClaims)
        {
            SymmetricSecurityKey authSigningKey = new(Encoding.ASCII.GetBytes(JwtKey));
            var tokenExpiryTimeSpan = DateTime.Now.AddDays(1);
            SigningCredentials signingCredentials = new(authSigningKey, SecurityAlgorithms.HmacSha256);
            ClaimsIdentity claimIdentity = new(authClaims);

            SecurityTokenDescriptor securityTokenDescriptor = new() {
                Subject = claimIdentity,
                Expires = tokenExpiryTimeSpan,
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}

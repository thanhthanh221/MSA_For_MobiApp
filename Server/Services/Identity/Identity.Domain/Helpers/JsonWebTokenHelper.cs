using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Utils;
using Identity.Domain.IdentityConfig;
using Identity.Domain.Model;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Domain.Helpers
{
    public static class JsonWebTokenHelper
    {
        public static async Task<string> GenerateJsonWebToken(ApplicationUser user, UserManager userManager)
        {
            SymmetricSecurityKey authSigningKey = new(Encoding.ASCII.GetBytes(ApplicationKeyUtils.Key));
            SigningCredentials signingCredentials = new(authSigningKey, SecurityAlgorithms.HmacSha256);
            // Role
            var userRoles = await userManager.GetRolesAsync(user);
            List<Claim> claims = new() {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserName", user.UserName),
                new Claim("Id", user.Id.ToString()),
            };
            userRoles.ToList().ForEach(c => {
                claims.Add(new Claim(ClaimTypes.Role, c));
            });
            ClaimsIdentity claimIdentity = new(claims);
            
            SecurityTokenDescriptor securityTokenDescriptor = new() {
                Subject = claimIdentity,
                Expires = DateTime.UtcNow.AddSeconds(20),
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
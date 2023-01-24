using System.Security.Cryptography;

namespace Identity.Domain.Helpers
{
    public static class RefreshTokenHelper
    {
        public static string GenerateRefreshToken()
        {
            var random = new byte[32];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(random);

            return Convert.ToBase64String(random);
        }
    }
}
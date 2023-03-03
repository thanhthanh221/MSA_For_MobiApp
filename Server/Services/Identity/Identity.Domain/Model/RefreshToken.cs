using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Model
{
    public class RefreshToken
    {
        public RefreshToken()
        {
        }

        public RefreshToken(
            string token, string jwtId, bool isUsed, bool isRevoked, ApplicationUser user)
        {
            Token = token;
            JwtId = jwtId;
            IsUsed = isUsed;
            IsRevoked = isRevoked;
            IssuedAt = DateTime.UtcNow;
            ExpiredAt = DateTime.UtcNow.AddHours(1);
            User = user;
        }

        [Key]
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime IssuedAt { get; set; }
        // Thời gian hết hạn
        public DateTime ExpiredAt { get; set; }
        
    }
}
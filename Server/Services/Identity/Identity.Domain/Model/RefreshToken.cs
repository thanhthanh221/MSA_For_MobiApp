using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            Id = Guid.NewGuid();
            Token = token;
            JwtId = jwtId;
            IsUsed = isUsed;
            IsRevoked = isRevoked;
            IssuedAt = DateTime.UtcNow;
            ExpiredAt = DateTime.UtcNow.AddHours(1);
            User = user;
        }

        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        public string Token { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime IssuedAt { get; set; }
        // Thời gian hết hạn
        public DateTime ExpiredAt { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
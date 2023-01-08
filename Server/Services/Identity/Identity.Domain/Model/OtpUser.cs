using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Model
{
    public class OtpUser
    {
        public OtpUser()
        {
        }

        public OtpUser(ApplicationUser user)
        {
            OtpHash = "";
            DateTimeCreate = DateTime.UtcNow;
            SecondsExpire = 60;
            CountSubmit = 0;
            User = user;
        }
        [Key]
        public Guid UserId { get; set; }
        public string OtpHash { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public int SecondsExpire { get; set; }
        public int CountSubmit { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
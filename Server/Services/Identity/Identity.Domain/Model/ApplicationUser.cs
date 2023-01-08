using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using OtpNet;

namespace Identity.Domain.Model
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Column(TypeName = "Money")]
        public decimal UsedMoney { get; private set; }
        public int QuantityOrders { get; private set; }

        [Column(TypeName = "DATE")]
        public DateTime? DateOfBirth { get; private set; }
        public bool? Sex { get; private set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Job { get; private set; }
        public virtual OtpUser Otp { get; set; }
        public virtual List<Address> Address { get; private set; }

        public void AddAddress(string city, string district, string commune, string street, string detail)
        {
            Address.Add(new Address(city, district, commune, street, detail, this));
        }

        public void EditProfile(bool? Sex, DateTime? DateOfBirth, string Job)
        {
            if (Sex != null) { this.Sex = Sex; }
            if (DateOfBirth != null) { this.DateOfBirth = DateOfBirth; }
            if (Job != null) { this.Job = Job; }
        }
        public void ClearOtp(string hex)
        {
            Otp.OtpHash = hex;
            Otp.DateTimeCreate = DateTime.UtcNow;
        }
        public void VerifyOtpTrue()
        {
            Otp.OtpHash = "";
            Otp.CountSubmit = 0;
        }
    }
}

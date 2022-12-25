using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Model
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Column(TypeName = "Money")]
        public decimal UsedMoney { get; private set; }
        public int QuantityOrders { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public virtual List<Address> Address { get; private set; }

        public void AddAddress(string city, string district, string commune, string street, string detail)
        {
            Address.Add(new Address(city, district, commune, street, detail, this));
        }
    }
}

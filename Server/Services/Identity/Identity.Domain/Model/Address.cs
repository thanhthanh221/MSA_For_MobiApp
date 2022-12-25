using Application.Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Domain.Model
{
    public class Address : ValueObject
    {
        public Address()
        {
        }

        public Address(string city, string district, string commune, string street, string detail, ApplicationUser user)
        {
            City = city;
            District = district;
            Commune = commune;
            Street = street;
            Detail = detail;
            User = user;
        }

        public string City { get; private set; }        // thành phố/tỉnh
        public string District { get; private set; }    // huyện/quận
        public string Commune { get; private set; }     // xã/phường
        public string Street { get; private set; }    // đường
        public string Detail { get; private set; }       // Mô tả vị trí

        // 1- 1
        public virtual ApplicationUser User { get; private set; }
        [Key]
        public Guid UserId { get; private set; }

    }
}
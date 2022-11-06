using Order.Domain.Core.Models;

namespace Order.Domain.Model
{
    public class Address : ValueObject
    {
        public Address()
        {
        }

        public Address(string city, string district, string commune, string street, string infomation)
        {
            this.city = city;
            this.district = district;
            this.commune = commune;
            this.street = street;
            this.infomation = infomation;
        }

        public String city { get; private set; }        // thành phố/tỉnh
        public String district { get; private set; }     // huyện/quận
        public String commune {get; private set;}    // xã/phường
        public String street { get; private set; }   // đường
        public String infomation {get; private set;} // Mô tả vị trí

    }
}

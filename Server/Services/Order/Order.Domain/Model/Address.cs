using Order.Domain.Core.Models;

namespace Order.Domain.Model
{
    public class Address : ValueObject
    {
        public Address()
        {
        }

        public Address(string city,
                       string district,
                       string commune,
                       string street,
                       string detail,
                       OrderAggregate order)
        {
            this.city = city;
            this.district = district;
            this.commune = commune;
            this.street = street;
            this.detail = detail;
            this.order = order;
        }

        public string city { get; private set; }        // thành phố/tỉnh
        public string district { get; private set; }    // huyện/quận
        public string commune {get; private set;}     // xã/phường
        public string street { get; private set; }    // đường
        public string detail {get; private set;}       // Mô tả vị trí

        // 1- 1
        public virtual OrderAggregate order {get; private set;}
        public Guid orderId {get; private set;}

    }
}

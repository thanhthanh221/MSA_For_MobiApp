
using Market.Domain.Interface;

namespace Market.Domain.Model
{
    public class Coupon : IAggregate
    {
        public Coupon()
        {
        }

        public Coupon(string name,
            string descretion,
            string value,
            decimal minPriceOrder,
            decimal moneyIsReduced,
            int quantity,
            DateTime expired)
        {
            Id = Guid.NewGuid();
            Name = name;
            Descretion = descretion;
            Value = value;
            MinPriceOrder = minPriceOrder;
            MoneyIsReduced = moneyIsReduced;
            Quantity = quantity;
            Expired = expired;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Descretion { get; private set; }
        public string Value { get; private set; }
        public decimal MinPriceOrder { get; private set; }
        public decimal MoneyIsReduced { get; private set; }
        public int Quantity { get; private set; }
        public DateTime Expired { get; private set; }
    }
}
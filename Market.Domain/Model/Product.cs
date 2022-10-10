using Market.Domain.Core.Models;

namespace Market.Domain.Model
{
    public class Product : EntityAudit
    {
        public Product()
        {
        }

        public Product(string name, decimal price, byte[] image, int calo, string descretion, 
            string alias, int warranty, decimal promotionPrice, int quantity, decimal originalPrice)
        {
            Name = name;
            Price = price;
            Image = image;
            Calo = calo;
            Descretion = descretion;
            Alias = alias;
            Warranty = warranty;
            PromotionPrice = promotionPrice;
            Quantity = quantity;
            OriginalPrice = originalPrice;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Byte[] Image { get; private set; }
        public int Calo { get; private set; }
        public string Descretion { get; private set; }
        public string Alias { get; private set; }
        public int Warranty { get; private set; } // bảo hành
        public decimal PromotionPrice { get; private set; } // giá khuyến mãi
        public int Quantity { get; private set; }
        public decimal OriginalPrice { get; private set; }
    }
}
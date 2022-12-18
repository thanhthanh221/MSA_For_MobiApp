using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Domain.ProductService.Model
{
    public class ProductType
    {
        [BsonElement("Tên Kiểu")]
        public string ValueType { get; set; }

        [BsonElement("Giá")]
        public decimal PriceType { get; set; }
        
        [BsonElement("Số Lượng")]
        [Range(0, int.MaxValue)]
        public int QuantityType { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is not ProductType) {
                return false;
            }

            return (obj as ProductType).ValueType.Equals(ValueType);
        }

        public override int GetHashCode()
        {
            return ValueType.GetHashCode();
        }
    }
}
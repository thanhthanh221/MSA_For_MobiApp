using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Market.Domain.Interface;

namespace Market.Domain.Model
{
    public class Product : IAggregate
    {
        public Product()
        {
        }

        public Product(
            string name,
            int calo,
            string descretion,
            string typeName,
            HashSet<TypeProduct> typeProducts,
            Guid userId,
            string userName,
            string image,
            List<Category> categories,
            TimeSpan timeOrder)
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            Categories = categories;
            UserLikeProduct = new HashSet<Guid>();
            CountView = 0;
            Star = 0;
            Name = name;
            Price = typeProducts.Min(ty => ty.PriceType);
            Calo = calo;
            TypeName = typeName;
            TypeProducts = typeProducts;
            Descretion = descretion;
            UserId = userId;
            UserName = userName;
            Image = image;
            TimeOrder = timeOrder;
        }
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Tên sản phẩm")]
        public string Name { get; set; }

        [BsonElement("Giá")]
        public decimal Price { get; set; }

        [BsonElement("Calo")]
        public int Calo { get; set; }
        [BsonElement("Mô tả")]
        public string Descretion { get; set; }

        [BsonElement("Tên Loại")]
        public string TypeName { get; set; }
        [BsonElement("Phân loại")]
        public HashSet<TypeProduct> TypeProducts { get; set; }

        [BsonElement("Sao")]
        public double Star { get; set; }
        [BsonElement("Lượt xem")]
        public int CountView { get; set; }
        [BsonElement("Người Thích")]
        public HashSet<Guid> UserLikeProduct { get; set; }

        [BsonElement("Ngày thêm")]
        public DateTime CreateAt { get; set; }

        [BsonElement("Mã người tạo")]
        public Guid UserId { get; set; }

        [BsonElement("Tên người tạo")]
        public string UserName { get; set; }

        [BsonElement("Ảnh")]
        public string Image { get; set; }

        [BsonElement("Danh mục sản phẩm")]
        public List<Category> Categories { get; set; }
        [BsonElement("Thời gian đặt hàng")]
        public TimeSpan TimeOrder { get; set; }


        public void UpdateNumberLike(Guid userId)
        {
            if (UserLikeProduct.Contains(userId)) {
                UserLikeProduct.Remove(userId);
                return;
            }
            UserLikeProduct.Add(userId);
        }
        public bool UpdatePriceProduct(decimal newPrice)
        {
            if (newPrice == Price || newPrice <= 0) {
                return false;
            }
            Price = newPrice;
            return true;
        }

        public void UpdateQuantityProduct(string typeValue, int newQuantity)
        {
            foreach (var typePro in from typePro in TypeProducts
                                    where typePro.TypeValue.Equals(typeValue)
                                    select typePro) {
                typePro.QuantityType = newQuantity;
            }
        }
    }

    public class TypeProduct
    {
        [BsonElement("Tên Kiểu")]
        public string TypeValue { get; set; }
        [BsonElement("Giá")]
        public decimal PriceType { get; set; }
        [BsonElement("Số Lượng")]
        [Range(0, int.MaxValue)]
        public int QuantityType { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is not TypeProduct) {
                return false;
            }

            return (obj as TypeProduct).TypeValue.Equals(TypeValue);
        }

        public override int GetHashCode()
        {
            return TypeValue.GetHashCode();
        }
    }
}
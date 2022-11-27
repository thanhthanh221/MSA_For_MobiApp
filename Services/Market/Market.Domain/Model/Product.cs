using Market.Domain.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Domain.Model
{
    public class Product : IAggregate
    {
        public Product()
        {
        }

        public Product(
            string name,
            decimal price,
            int calo,
            string descretion,
            int quantity,
            Guid userId,
            string userName,
            string image,
            HashSet<Category> categories)
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            Categories = categories;
            UserLikeProduct = new HashSet<Guid>();
            CountView = 0;
            Name = name;
            Price = price;
            Calo = calo;
            Descretion = descretion;
            Quantity = quantity;
            UserId = userId;
            UserName = userName;
            Image = image;
        }
        [BsonId]
        public Guid Id { get; private set; }

        [BsonElement("Tên sản phẩm")]
        public string Name { get; private set; }

        [BsonElement("Giá")]
        public decimal Price { get; private set; }

        [BsonElement("Calo")]
        public int Calo { get; private set; }
        [BsonElement("Mô tả")]
        public string Descretion { get; private set; }
        [BsonElement("Số lượng")]
        public int Quantity { get; private set; }
        [BsonElement("Lượt xem")]

        public int CountView { get; private set; }
        [BsonElement("Người Thích")]
        public HashSet<Guid> UserLikeProduct { get; private set; }

        [BsonElement("Ngày thêm")]
        public DateTime CreateAt { get; private set; }

        [BsonElement("Mã người tạo")]
        public Guid UserId { get; private set; }

        [BsonElement("Tên người tạo")]
        public string UserName { get; private set; }

        [BsonElement("Ảnh")]
        public string Image { get; private set; }

        [BsonElement("Danh mục sản phẩm")]
        public HashSet<Category> Categories { get; private set; }

        // Order Product using Saga Or
        public void UpdateQuantityProduct(int newQuantity)
        {
            if (newQuantity > 0) {
                Quantity = newQuantity;
            }
        }

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
            if(newPrice == Price || newPrice <= 0)
            {
                return false;
            }
            Price = newPrice;
            return true;
        }
    }
}
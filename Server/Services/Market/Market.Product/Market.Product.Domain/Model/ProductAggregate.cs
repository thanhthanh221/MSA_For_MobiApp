using Application.Common.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Product.Domain.Model
{
    public class ProductAggregate : IAggregateRoot
    {
        public ProductAggregate()
        {
        }

        public ProductAggregate(
            string name,
            int calo,
            string descretion,
            string typeName,
            List<ProductType> productTypes,
            List<ProductCategory> categories,
            string fileName,
            TimeSpan timeOrder)
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            UserLikeProduct = new List<Guid>();
            CountView = 0;
            Star = 0;
            Name = name;
            Calo = calo;
            ProductStatus = ProductStatus.Submitted;
            TypeName = typeName;
            ProductTypes = productTypes;
            Categories = categories;
            Descretion = descretion;
            FileName = fileName;
            TimeOrder = timeOrder;
            Price = productTypes.Min(p => p.PriceType);
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
        [BsonElement("Sao")]
        public double Star { get; set; }
        [BsonElement("Lượt xem")]
        public int CountView { get; set; }
        [BsonElement("Người Thích")]
        public List<Guid> UserLikeProduct { get; set; }

        [BsonElement("Ngày thêm")]
        public DateTime CreateAt { get; set; }

        [BsonElement("Ảnh")]
        public string FileName { get; set; }
        [BsonElement("Phân loại")]
        public List<ProductType> ProductTypes { get; set; }
        
        [BsonElement("Danh mục sản phẩm")]
        public List<ProductCategory> Categories { get; set; }
        [BsonElement("Trạng thái sản phẩm")]
        public ProductStatus ProductStatus { get; set; }
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
        public void AddCategory(Guid CateId, string CategoryName)
        {
            Categories.Add(new ProductCategory(CateId, CategoryName));
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
            foreach (var typePro in from typePro in ProductTypes
                                    where typePro.ValueType.Equals(typeValue)
                                    select typePro) {
                typePro.QuantityType = newQuantity;
            }
        }
    }
}
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Domain.ProductService.Model
{
    public class ProductCategory
    {
        public ProductCategory()
        {
        }

        public ProductCategory(Guid categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        [BsonElement("Mã danh mục")]
        public Guid CategoryId {get; private set;}
        [BsonElement("Tên danh mục")]
        public string CategoryName {get; private set;}
    }
}
using Application.Common.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Product.Domain.Model
{
    public class ProductCategory : ValueObject
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
        public Guid CategoryId { get; set; }
        [BsonElement("Tên danh mục")]
        public string CategoryName { get; set; }
    }
}
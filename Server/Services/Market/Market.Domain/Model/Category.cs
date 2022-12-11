using Market.Domain.Interface;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Market.Domain.Model
{
    public class Category : IAggregate
    {
        public Category(string name,
                        string image)
        {
            Id = Guid.NewGuid();
            ParentCategory = new List<Category>();
            Name = name;
            Image = image;
        }
        [BsonId]
        [JsonProperty(PropertyName = "CateId")]
        public Guid Id { get; set; }
        [BsonElement("Tên danh mục")]
        public string Name { get; set; }
        [BsonElement("Danh mục cha")]
        [JsonProperty]
        public List<Category> ParentCategory { set; get; }
        [BsonElement("Ảnh")]
        public string Image { get; set; }

        public void SetParentCategory(HashSet<Category> categories)
        {

            if (categories != null) {
                ParentCategory = categories.ToList();
            }

        }
    }
}

using Application.Common.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Domain.CategoryService.Model
{
    public class CategoryAggregate : IAggregateRoot
    {
        public CategoryAggregate(Guid id, string name, string image)
        {
            Id = id;
            Name = name;
            Image = image;
        }

        [BsonId]
        public Guid Id { get; private set; }
        [BsonElement("Tên danh mục")]
        public string Name { get; private set; }
        [BsonElement("Ảnh")]
        public string Image { get; private set; }


    }
}
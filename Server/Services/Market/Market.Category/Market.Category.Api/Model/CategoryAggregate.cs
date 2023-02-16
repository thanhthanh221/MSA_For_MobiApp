using Application.Common.Helper;
using Application.Common.Model;
using Market.Category.Api.Dtos;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Category.Api.Model
{
    public class CategoryAggregate : IAggregateRoot
    {
        public CategoryAggregate(string name, string icon)
        {
            Id = Guid.NewGuid();
            Name = name;
            Icon = icon;
        }

        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("Tên danh mục")]
        public string Name { get; set; }
        [BsonElement("Ảnh")]
        public string Icon { get; set; }

        public static async Task<CategoryAggregate> CreateNewCategory(CreateCategory createData)
        {
            string image = await UploadFileHelper.SaveImage(createData.Icon, null);
            return new CategoryAggregate(createData.Name, image);
        }
    }
}
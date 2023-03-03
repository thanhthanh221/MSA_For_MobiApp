using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Market.Product.Domain.Events.CreatedProduct
{
    public class CreatedProductEvent
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
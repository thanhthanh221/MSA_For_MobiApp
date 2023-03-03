using Application.Common.Model;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Market.Product.Domain.Model
{
    public class ProductStatus : Enumeration
    {
        public ProductStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        // Product Status
        public static ProductStatus Submitted { get; set; } = new ProductStatus(1, "Đang xác thực");
        public static ProductStatus Success { get; set; } = new ProductStatus(2, "Thành công");
    }
}
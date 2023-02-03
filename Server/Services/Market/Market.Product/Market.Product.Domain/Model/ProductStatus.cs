using Application.Common.Model;

namespace Market.Product.Domain.Model
{
    public class ProductStatus : Enumeration
    {
        public ProductStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        // Product Status
        public static ProductStatus Submitted { get; private set; } = new ProductStatus(1, "Đang xác thực");
        public static ProductStatus Success { get; private set; } = new ProductStatus(2, "Đã xác thực");

    }
}
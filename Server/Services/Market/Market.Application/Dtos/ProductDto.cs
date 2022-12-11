namespace Market.Application.Dtos
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Calo { get; set; }
        public decimal Price { get; set; }
        public TimeSpan TimeOrder { get; set; }
        public bool CheckFavourite { get; set; }
        public string TypeName { get; set; }
        public List<TypeProductDto> TypeProductDtos { get; set; }
        public string Image { get; set; }
    }

    public class TypeProductDto
    {
        public TypeProductDto(string typeValue, decimal priceType, int quantityType)
        {
            TypeValue = typeValue;
            PriceType = priceType;
            QuantityType = quantityType;
        }

        public string TypeValue { get; set; }
        public decimal PriceType { get; set; }
        public int QuantityType { get; set; }
    }
}
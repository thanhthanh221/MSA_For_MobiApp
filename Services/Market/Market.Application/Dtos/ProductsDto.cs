namespace Market.Application.Dtos
{
    public class ProductsDto
    {
        public Guid ProductId { get; set; }
        public string ProductName {get; set;}
        public int Calo { get; set; }
        public decimal Price { get; set; }
        public bool CheckFavourite { get; set; }
        public List<Guid> Categories { get; set; }
        public double Star { get; set; }
        public string Image { get; set; }

    }
}
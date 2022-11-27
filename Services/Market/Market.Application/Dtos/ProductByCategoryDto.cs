namespace Market.Application.Dtos
{
    public class ProductByCategoryDto
    {
        public Guid ProductId {get; set;}
        public int Calo {get; set;}
        public decimal Price {get; set;}
        public bool CheckFavourite {get; set;}
        
    }
}
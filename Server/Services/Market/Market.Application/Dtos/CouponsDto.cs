namespace Market.Application.Dtos
{
    public class CouponsDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
        public int Quantity { get; private set; }
        public DateTime Expired { get; private set; }
    }
}

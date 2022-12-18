namespace Market.Application.Dtos
{
    public class CouponDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<string> Descretion { get; private set; }
        public string Value { get; private set; }
        public DateTime Expired { get; private set; }
    }
}

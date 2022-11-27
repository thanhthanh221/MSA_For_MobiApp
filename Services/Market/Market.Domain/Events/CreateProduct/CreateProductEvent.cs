using Market.Domain.Model;
using MediatR;

namespace Market.Domain.Events.CreateProduct
{
    public class CreateProductEvent : INotification
    {
        public Product Product { get; private set; }
        public DateTime TimeSpan { get; private set; }
        public CreateProductEvent(Product product)
        {
            Product = product;
            TimeSpan = DateTime.Now;
        }
    }
}
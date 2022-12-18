using Application.Common.Events;

namespace EventBus.Messages.Events
{
    public class CreateProductEvent : IntegrationBaseEvent
    {
        public CreateProductEvent(Guid productId, List<Guid> categoriesId)
        {
            ProductId = productId;
            CategoriesId = categoriesId;
        }

        public Guid ProductId { get; set; }
        public List<Guid> CategoriesId { get; set; }
    }
}

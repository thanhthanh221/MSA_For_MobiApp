using MediatR;

namespace Market.Product.Domain.Events.UpdateCache
{
    public class UpdateCacheEvent : INotification   
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
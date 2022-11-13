using Order.Domain.Core.Commands;
using Order.Domain.Core.Events;

namespace Order.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        // gửi command xử lý
        Task SendCommand<T>(T command) where T : Command;
        
        // Gửi Event
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}

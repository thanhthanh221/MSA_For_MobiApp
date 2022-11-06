using Order.Domain.Core.Commands;

namespace Order.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        // gửi command xử lý
        Task SendCommand<T>(T command) where T : Command;
    }
}

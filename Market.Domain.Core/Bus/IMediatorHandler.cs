using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Core.Commands;
using Market.Domain.Core.Events;

namespace Market.Domain.Core.Bus
{
    // Truyền tải Service => Command
    public interface IMediatorHandler
    {
        // gửi command xử lý
        Task SendCommand<T>(T command) where T : Command;
        // đẩy sự kiện
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}

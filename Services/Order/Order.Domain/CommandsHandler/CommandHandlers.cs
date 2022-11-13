using Order.Domain.Core.Bus;

namespace Order.Domain.CommandsHandler
{
    public class CommandHandlers
    {
        protected readonly IMediatorHandler bus;

        public CommandHandlers(IMediatorHandler bus)
        {
            this.bus = bus;
        }
    }
}

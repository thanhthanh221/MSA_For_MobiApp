using MediatR;
using Order.Domain.Core.Commands;

namespace Order.Domain.Core.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediator;

        public InMemoryBus(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }
    }
}

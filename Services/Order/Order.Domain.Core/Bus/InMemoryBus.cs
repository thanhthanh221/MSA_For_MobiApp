using MediatR;
using Order.Domain.Core.Commands;
using Order.Domain.Core.Events;

namespace Order.Domain.Core.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediator;

        public InMemoryBus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }
    }
}

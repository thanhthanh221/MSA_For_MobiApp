using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Dtos;
using Order.Domain.Commands.CancelOrder;
using Order.Domain.Commands.CreateOrder;
using Order.Domain.Commands.SetOrderStatus;
using Order.Domain.Core.Bus;
using Order.Domain.Interface;

namespace Order.Application.Api.Controllers
{
    [Route("OrderService/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> logger;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IMediator mediator;
        private readonly IOrderRepository orderRepository;

        public OrderController(ILogger<OrderController> logger,
                               IPublishEndpoint publishEndpoint,
                               IMediator mediator,
                               IOrderRepository orderRepository)
        {
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
            this.mediator = mediator;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrderAsync(OrderCreateDto createOrderDto)
        {
            try {
                List<OrderItemCheckoutEvent> orderItemCheckoutEvents = new List<OrderItemCheckoutEvent>();

                foreach (var orProduct in createOrderDto.orderItemCommands) 
                {
                    orderItemCheckoutEvents.Add(
                        new OrderItemCheckoutEvent() 
                        {
                            productId = orProduct.productId,
                            count = orProduct.count,
                        }
                    );
                }
                OrderCheckoutEvent orderCheckout = new OrderCheckoutEvent()
                {
                    userId = createOrderDto.userId,
                    products = orderItemCheckoutEvents,
                    checkOrchestration = true,
                    CountCheckSaga = 0
                };


                logger.LogInformation($"Publish Message To Queue {DateTime.Now}");

                await publishEndpoint.Publish<OrderCheckoutEvent>(orderCheckout);

                return Accepted();
            }
            catch (System.Exception) {

                throw;
            }


        }

        [HttpPatch("orderId")]
        public async Task<ActionResult> SetOrderStatusAsync(Guid orderId, int statusId)
        {
            try {
                SetOrderStatusCommand setOrderStatusCommand = new SetOrderStatusCommand(orderId, statusId);
                Boolean checkSetOrderStatus = await mediator.Send(setOrderStatusCommand);

                if (!checkSetOrderStatus) {
                    return NotFound();
                }

                return NoContent();
            }
            catch (System.Exception) {
                logger.LogWarning($"Bug 500 In Controller : Order - Action : SetOrderStatus - Time: {DateTime.UtcNow}");
                throw;
            }
        }

        [HttpDelete("orderId")]
        public async Task<ActionResult> CancelOrderAsync(Guid orderId)
        {
            try {
                CancelOrderCommand cancelOrderCommand = new CancelOrderCommand(orderId);
                Boolean checkCancleOrder = await mediator.Send(cancelOrderCommand);

                if (!checkCancleOrder) {
                    return NotFound();
                }
                return NoContent();
            }
            catch (System.Exception) {
                logger.LogWarning($"Bug 500 In Controller : Order - Action : CancelOrderAsync - Time: {DateTime.UtcNow}");
                throw;
            }
        }
    }
}
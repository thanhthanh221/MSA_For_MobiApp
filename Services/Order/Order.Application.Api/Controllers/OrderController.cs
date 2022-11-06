using Microsoft.AspNetCore.Mvc;
using Order.Application.Dtos;
using Order.Application.Interfaces;

namespace Order.Application.Api.Controllers
{
    [Route("OrderService/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<OrderReadDto> orderDtos = await orderService.GetAllAsync();
                return Ok(orderDtos); 
            }
            catch (System.Exception)
            {
                logger.LogWarning("Log 500 In Action: GetAllAsync - Controller : Order");
                throw;
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<OrderReadDto>> GetByIdAsync(Guid Id)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return NotFound();
                }
                OrderReadDto orderReadDto = await orderService.GetByIdAsync(Id);

                if(orderService is null)
                {
                    return NotFound();
                }
                return Ok(Id);
            }
            catch (System.Exception)
            {
                logger.LogWarning("Log 500 In Action: GetByIdAsync - Controller : Order");
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(OrderWriteDto orderWriteDto)
        {
            await orderService.CreateAsync(orderWriteDto);


            return NoContent();
        }

        // PUT api/<OrderController>/5
        [HttpPut("Id")]
        public async Task<ActionResult> PutAsync(Guid Id, OrderWriteDto orderWriteDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return NotFound();
                }
                await orderService.UpdateAsync(orderWriteDto,Id);
                return NoContent();   
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

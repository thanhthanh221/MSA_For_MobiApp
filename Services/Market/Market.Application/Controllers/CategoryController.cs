using Market.Domain.Commands.CreateCategory;
using Microsoft.AspNetCore.Mvc;
namespace Market.Application.Controllers
{
    [Route("MarketService/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            this.logger = logger;
        }

        // Get All Product
        [HttpGet(Name = "GetAllCategory")]
        public async Task<ActionResult> GetAllAsync()
        {
            try {
                

                return Ok();
            }
            catch (System.Exception) {
                logger.LogInformation("500");
                throw;
            }
        }

        // Find Product By Id
        [HttpGet("Id", Name = "GetProductById")]
        public async Task<ActionResult> GetByIdAsync(Guid Id)
        {
            try {
                

                // if (categoryDto is null) {
                //     return NotFound();
                // }

                return Ok();
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }

        // POST api/<CategoryController>
        [HttpPost(Name ="CreateCategory")]
        public async Task<ActionResult> PostAsync([FromForm] CreateCategoryCommand command)
        {
            try {
                if (!ModelState.IsValid) {
                    return NotFound();
                }

                
                
                return NoContent();
            }
            catch (System.Exception) {
                logger.LogInformation("500");
                throw;
            }

        }
    }
}

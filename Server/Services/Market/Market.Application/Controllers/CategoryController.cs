using Market.Domain.Commands.CreateCategory;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Market.Application.Controllers
{
    [Route("MarketService/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;
        private readonly IMediator mediator;

        public CategoryController(
            ILogger<CategoryController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
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

        [Route("CreateCategory")]
        [HttpPost]
        public async Task<ActionResult> CreateCategoryAsync([FromForm] CreateCategoryCommand command)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.BadRequest();
                }

                return this.Ok();
            }
            catch (System.Exception) {
                logger.LogInformation("500");
                throw;
            }

        }
    }
}

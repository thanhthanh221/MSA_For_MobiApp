using Market.Application.Dtos;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Market.Application.Api.Controllers
{
    [Route("Market/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;
        private readonly ICategoryService categoryService;

        public CategoryController(ILogger<CategoryController> logger,
                                  ICategoryService categoryService)
        {
            this.logger = logger;
            this.categoryService = categoryService;
        }

        // Get All Product
        [HttpGet(Name = "GetAllCategory")]
        public async Task<ActionResult> GetAllAsync()
        {
            try {
                IEnumerable<CategoryReadDto> categoryReadDtos = await categoryService.GetAllAsync();

                return Ok(categoryReadDtos);
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
                CategoryReadDto categoryDto = await categoryService.GetByIdAsync(Id);

                if (categoryDto is null) {
                    return NotFound();
                }

                return Ok(categoryDto);
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] CategoryWriteDto categoryWriteDto)
        {
            try {
                if (!ModelState.IsValid) {
                    return NotFound();
                }
                await categoryService.CreateAsync(categoryWriteDto);
                return NoContent();
            }
            catch (System.Exception) {
                logger.LogInformation("500");
                throw;
            }

        }

        // PUT api/<CategoryController>/5
        [HttpPut("Id")]
        public async Task<ActionResult> PutAsync([FromForm] CategoryWriteDto categoryWriteDto, Guid Id)
        {
            try {
                if(!ModelState.IsValid)
                {
                    return NotFound();
                }
                await categoryService.UpdateAsync(categoryWriteDto, Id);
                return NoContent();
            }
            catch (System.Exception) {
                logger.LogInformation("500");
                throw;
            }


        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("Id")]
        public async Task<ActionResult> DeleteAsync(Guid Id)
        {
            try {
                await categoryService.DeleteAsync(Id);
                return NoContent();
            }
            catch (System.Exception) {
                logger.LogInformation("500");
                throw;
            }
        }
    }
}

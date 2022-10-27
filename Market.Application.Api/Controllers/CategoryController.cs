using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Market.Application.Api.Controllers
{
    [Route("Market/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ICategoryService categoryService;

        public CategoryController(ILogger logger,
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

                return Ok();
            }
            catch (System.Exception) {

                throw;
            }
        }

        // Find Product By Id
        [HttpGet("Id", Name = "GetProductById")]
        public async Task<ActionResult> GetByIdAsync(Guid Id)
        {
            return Ok();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("Id")]
        public void Delete(int id)
        {
        }
    }
}

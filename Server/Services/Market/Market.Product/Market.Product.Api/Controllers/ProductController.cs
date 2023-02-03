using Application.Common.Helper;
using Application.Common.Utils;
using Market.Product.Domain.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Market.Product.Api.Controllers
{
    [Route("ProductService/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("ProductFile/{productImageName}")]
        public async Task<ActionResult> ProductImageAsync(string productImageName)
        {
            try {
                string imageProductPath = $"Images/{productImageName}";
                var bytesImage = await System.IO.File.ReadAllBytesAsync(imageProductPath);
                var fileExtension = UploadFileHelper.GetFileExtension(productImageName);
                string mimetype = UploadFileHelper.GetImageMimeTypeFromImageFileExtension(fileExtension);
                return this.File(bytesImage, mimetype);
            }
            catch (Exception) {
                return this.StatusCode(500, new ApiResponseUtils(500, false, "Không tìm thấy hình ảnh"));
            }
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProductAsync([FromForm] CreateProductCommand createProductCommansd)
        {
            if (!ModelState.IsValid) { return this.BadRequest(); }
            var product = await mediator.Send(createProductCommansd);
            if (product is null) {
                return this.Ok(
                    new ApiResponseUtils(false, "Không tạo được sản phẩm", null)
            );
            }
            return this.CreatedAtAction(nameof(CreateProductAsync), product);
        }
    }
}

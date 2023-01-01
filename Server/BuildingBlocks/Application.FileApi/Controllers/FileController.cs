using Application.Common.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Application.FileApi.Controllers
{
    [Route("FileCommon/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet]
        [Route("ProductFile/{productImageName}")]
        public async Task<ActionResult> ProductImageAsync(string productImageName)
        {
            string imageProductPath = $"Images/ProductFile/{productImageName}";
            var bytesImage = await System.IO.File.ReadAllBytesAsync(imageProductPath);
            return this.File(bytesImage, "image/png");
        }
        [HttpGet]
        [Route("CategoryFile/{categoryImageName}")]
        public async Task<ActionResult> CategoryImageAsync(string categoryImageName)
        {
            string imageCategoryPath = $"Images/CategoryFile/{categoryImageName}";
            var bytesImage = await System.IO.File.ReadAllBytesAsync(imageCategoryPath);
            return this.File(bytesImage, "image/png");
        }
        [HttpPost]
        [Route("SaveFile")]
        public async Task<ActionResult> SaveProductImageAsync(IFormFile productImage, string FileType)
        {
            var imageFile = await UploadFileHelper.SaveImage(productImage, FileType);
            return this.Ok(imageFile);
        }

    }
}

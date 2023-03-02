using Application.Common.Helper;
using Application.Common.Repository;
using Application.Common.Utils;
using Market.Category.Api.Dtos;
using Market.Category.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Market.Category.Api.Controllers
{
    [Route("CategoryService/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<CategoryAggregate> categoryRepository;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(
            IRepository<CategoryAggregate> categoryRepository, ILogger<CategoryController> logger)
        {
            this.categoryRepository = categoryRepository;
            this.logger = logger;
        }
        [HttpGet]
        [Route("CategoryIcon/{CategoryId}")]
        public async Task<ActionResult> GetImageCategory(Guid CategoryId)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.StatusCode(400, new ApiResponseUtils(false, "Lỗi dữ liệu đầu vào"));
                }
                var category = await categoryRepository.GetByIdAsync(CategoryId);
                if (category is null) {
                    return this.Ok(new ApiResponseUtils(false, "Không tìm thấy sản phẩm có {Id}", CategoryId));
                }
                string imageProductPath = $"Images/{category.Icon}";
                var bytesImage = await System.IO.File.ReadAllBytesAsync(imageProductPath);
                var fileExtension = UploadFileHelper.GetFileExtension(category.Icon);
                string mimetype = UploadFileHelper.GetImageMimeTypeFromImageFileExtension(fileExtension);
                return this.File(bytesImage, mimetype);

            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message,null));
            }
        }

        [HttpGet]
        [Route("GetCategoryById/{CategoryId}")]
        public async Task<ActionResult> GetCategoryByIdAsync(Guid CategoryId)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.StatusCode(400, new ApiResponseUtils(false, "Lỗi dữ liệu đầu vào",null));
                }
                var category = await categoryRepository.GetByIdAsync(CategoryId);
                if (category is null) {
                    return this.Ok(new ApiResponseUtils(false, "Không tìm thấy sản phẩm có {Id}", CategoryId));
                }
                CategoryDto categoryDto = CategoryDto.ConverCategoryToDto(category);
                return this.Ok(new ApiResponseUtils(true, "Tìm thấy sản phẩm", categoryDto));
            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message));
            }
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<ActionResult> GetAllCategoryAsync()
        {
            try {
                if (!ModelState.IsValid) {
                    return this.StatusCode(400, new ApiResponseUtils(false, "Lỗi dữ liệu đầu vào"));
                }
                var categorys = await categoryRepository.GetAllAsync();
                if (categorys is null) {
                    return this.Ok(new ApiResponseUtils(false, "Không tìm thấy danh mục"));
                }
                var categoryDtos = categorys.Select(c => CategoryDto.ConverCategoryToDto(c)).OrderBy(c => c.Name);
                return this.Ok(new ApiResponseUtils(true, "Tìm thấy danh mục", categoryDtos));
            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message));
            }
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<ActionResult> CreateCategoryAsync([FromForm] CreateCategory createCategory)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.StatusCode(400, new ApiResponseUtils(false, "Lỗi dữ liệu đầu vào"));
                }
                var categorys = await categoryRepository.GetAllAsync();
                var checkCategoryName = categorys.Any(c =>
                                        c.Name.ToLower().Equals(createCategory.Name.ToLower().Trim()));
                if (checkCategoryName) {
                    return this.StatusCode(201, new ApiResponseUtils(false, "Đã tồn tại danh mục", null));
                }
                var category = await CategoryAggregate.CreateNewCategory(createCategory);
                await categoryRepository.CreateAsync(category);
                logger.LogInformation("Tạo một danh mục {Id} - {Name}", category.Id, category.Name);
                return this.StatusCode(201, category);
            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message));
            }
        }

        [HttpDelete]
        [Route("DeleteCategory/{CategoryId}")]
        public async Task<ActionResult> DeleteCategoryAsync(Guid CategoryId)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.StatusCode(400, new ApiResponseUtils(false, "Lỗi dữ liệu đầu vào"));
                }
                var category = await categoryRepository.GetByIdAsync(CategoryId);
                if (category is null) {
                    return this.StatusCode(400, new ApiResponseUtils(false, "Không tồn tại danh mục !"));
                }
                await categoryRepository.RemoveAsync(CategoryId);
                UploadFileHelper.DeleteImage(category.Icon, null);

                logger.LogInformation("Xóa danh mục {Id} - {Name}", category.Id, category.Name);
                return this.StatusCode(203, category);
            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message));
            }
        }
    }
}

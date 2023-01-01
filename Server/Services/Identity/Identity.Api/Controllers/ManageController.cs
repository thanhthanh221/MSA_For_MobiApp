using Identity.Api.Dto;
using Identity.Domain.Interfaces;
using Identity.Domain.ViewModel.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("IdentityService/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly IManageService manageService;
        public ManageController(IManageService manageService)
        {
            this.manageService = manageService;
        }
        [HttpGet]
        [Route("GetInfomation")]
        public async Task<IActionResult> GetUserInfomation(Guid userId)
        {
            try {
                if (!ModelState.IsValid) { return this.NotFound(); }
                var appUser = await manageService.GetUserInfomation(userId);
                if (appUser is null) { return this.Accepted(); }
                ManageInfomationDto userInfomation = ManageInfomationDto.ConvertAppUserToDto(appUser);
                return this.Ok(userInfomation);
            }
            catch (System.Exception) {
                return this.Unauthorized();
                throw;
            }
        }
        [HttpPatch]
        [Route("ChangeEmailUser")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> ChangeEmailAsync(ChangeEmailViewModel changeEmail)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var checkResponse = await manageService.ChangeEmailAsync(changeEmail);
                if (checkResponse.Status == 404) { return this.NotFound(checkResponse.Message); }
                else if (checkResponse.Status == 400) { return this.BadRequest(checkResponse.Message); }
                return this.Ok(checkResponse.Message);
            }
            catch (System.Exception) {
                return this.Unauthorized();
                throw;
            }
        }
        [HttpPut]
        [Route("EditExtraProfileUser")]
        public async Task<ActionResult> EditProfileAsync([FromForm]EditExtraProfileViewModel editExtraProfile)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var checkResponse = await manageService.EditProfileAsync(editExtraProfile);
                if (checkResponse.Status == 202) { return this.Accepted(checkResponse.Message); }
                if (checkResponse.Status == 404) { return this.NotFound(checkResponse.Message); }
                return this.Ok(checkResponse.Message);
            }
            catch (System.Exception) {
                return this.Unauthorized();
                throw;
            }
        }
    }

}

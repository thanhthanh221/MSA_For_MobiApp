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
        [Route("GetInfomation/{userId}")]
        public async Task<IActionResult> GetUserInfomation(Guid userId)
        {
            try {
                if (!ModelState.IsValid) { return this.NotFound(); }
                var appUser = await manageService.GetUserInfomation(userId);
                if (appUser is null) { return this.Accepted(); }
                ManageInfomationDto userInfomation = ManageInfomationDto.ConvertAppUserToDto(appUser);
                return this.Ok(userInfomation);
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
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
                if (checkResponse.Status == 404) { return this.NotFound(checkResponse.Response); }
                else if (checkResponse.Status == 400) { return this.BadRequest(checkResponse.Response); }
                return this.Ok(checkResponse.Response);
            }
            catch (Exception) {
                return this.Unauthorized();
                throw;
            }
        }
        [HttpPatch]
        [Route("AddPhoneNumber")]
        public async Task<ActionResult> AddPhoneNumberAsync(AddPhoneNumberViewModel addPhoneNumber)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var checkResponse = await manageService.AddPhoneNumberService(addPhoneNumber);
                return this.Ok(checkResponse.Response);
            }
            catch (Exception) {
                return this.Unauthorized();
                throw;
            }

        }
        [HttpPost]
        [Route("VerifyPhoneNumber")]
        public async Task<ActionResult> VerifyPhoneNumberAsync(VerifyPhoneNumberViewModel verifyPhoneNumber)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var response = await manageService.VerifyPhoneNumberService(verifyPhoneNumber);
                if (response.Status == 404) { return this.NotFound(); }
                return this.Ok(new { response.Response, response.Verify });
            }
            catch (System.Exception) {
                return this.StatusCode(500);
            }
        }
        [HttpPut]
        [Route("EditExtraProfileUser")]
        public async Task<ActionResult> EditProfileAsync([FromForm] EditExtraProfileViewModel editExtraProfile)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var checkResponse = await manageService.EditProfileAsync(editExtraProfile);
                if (checkResponse.Status == 202) { return this.Accepted(checkResponse.Response); }
                if (checkResponse.Status == 404) { return this.NotFound(checkResponse.Response); }
                return this.Ok(checkResponse.Response);
            }
            catch (System.Exception) {
                return this.StatusCode(500);
                throw;
            }
        }
    }

}

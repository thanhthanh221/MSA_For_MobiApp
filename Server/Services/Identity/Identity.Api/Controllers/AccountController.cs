using Application.Common.Utils;
using Identity.Domain.Interfaces;
using Identity.Domain.ViewModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("IdentityService/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(
            IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            try {
                if (!ModelState.IsValid) { return this.NotFound(); }
                var token = await accountService.LoginAsync(loginViewModel);
                return token != null ? this.Ok(token) : this.BadRequest();
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }
        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterAsync(RegisterViewModel registerViewModel)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(new { message = "Dữ liệu không phù hợp" }); }
                var response = await accountService.RegisterAsync(registerViewModel);
                return response != null ? this.Ok(response) : this.Unauthorized();
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }
        [Route("ExternalLogin")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginAsync(ExternalLoginViewModel model)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var response = await accountService.ExternalLoginService(model);
                if (response.Status == 302) { return this.Ok(new { response.Response, response.Verify }); }
                return this.Ok(new { response.Response, response.Verify });
            }
            catch (Exception) {
                return this.StatusCode(500);
            }
        }
        [Route("ExternalLoginConfirmation")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginConfirmationAsync(ExternalLoginConfirmationViewModel model)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var response = await accountService.ExternalLoginConfirmationService(model);
                if (response.Status == 400) { return this.Ok(new { response.Response, response.Verify }); }
                return this.Ok(new { response.Response, response.Verify });
            }
            catch (System.Exception) {
                return this.StatusCode(500);
            }
        }
        [Route("RefreshNewToken")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> RefreshNewTokenAsync(TokenViewModel tokenViewModel)
        {
            try {
                if (!ModelState.IsValid) { return this.StatusCode(400); }
                var newToken = await accountService.RefreshNewToken(tokenViewModel);
                return this.Ok(newToken);
            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(500, false, ex.Message));
            }
        }


        [Route("ChangePassword")]
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> ChangePasswordAsync(ResetPasswordViewModel resetPasswordViewModel)
        {
            try {
                if (!ModelState.IsValid) { return this.NotFound(); }
                var check = await accountService.ChangePasswordAsync(resetPasswordViewModel);
                return check != null ? this.Ok(check) : this.BadRequest(check);
            }
            catch (Exception) {
                return this.StatusCode(500);
            }
        }
    }
}

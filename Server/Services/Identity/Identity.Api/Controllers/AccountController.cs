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

        public AccountController(IAccountService accountService)
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
            catch (System.Exception) {
                return this.Unauthorized();
                throw;
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
            catch (System.Exception) {
                return this.Unauthorized();
                throw;
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
            catch (System.Exception) {
                return this.Unauthorized();
                throw;
            }
        }
    }
}

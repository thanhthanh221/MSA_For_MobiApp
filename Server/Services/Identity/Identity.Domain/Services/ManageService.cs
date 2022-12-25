using Identity.Domain.Interfaces;
using Identity.Domain.Model;
using Identity.Domain.ViewModel.Manage;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Services
{
    public class ManageService : IManageService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ManageService(
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task<ResponseClient> ChangeEmailAsync(ChangeEmailViewModel changeEmail)
        {
            var appUser = await userManager.FindByIdAsync(changeEmail.UserId.ToString());
            if (appUser is null) { return new("Không tìm thấy người dùng", 404); }
            // Lấy Email của user
            var findUserByNewEmail = await userManager.FindByEmailAsync(changeEmail.NewEmail);
            if (findUserByNewEmail != null) { return new("Email đã có người sử dụng", 400); }
            var changeEmailUser = await userManager.SetEmailAsync(appUser, changeEmail.NewEmail);
            if (!changeEmailUser.Succeeded) { return new("Đổi Emai không thành công", 400); }
            return new("Đổi Email Thành công!", 200);
        }

        public async Task<ApplicationUser> GetUserInfomation(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user is null) { return null; }
            return user;
        }
    }
}
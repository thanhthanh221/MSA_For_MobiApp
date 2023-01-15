using System.Text;
using Identity.Domain.IdentityConfig;
using Identity.Domain.Interfaces;
using Identity.Domain.Model;
using Identity.Domain.ViewModel.Manage;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Identity.Domain.Services
{
    public class ManageService : IManageService
    {
        private const string messageApi = "https://localhost:7050/MessageService/Message/SmsPhoneOtp";
        private readonly UserManager userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IOtpManager otpManager;
        private readonly HttpClient httpClient;

        public ManageService(
            UserManager userManager, IOtpManager otpManager, HttpClient httpClient, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.otpManager = otpManager;
            this.httpClient = httpClient;
            this.signInManager = signInManager;
        }

        public async Task<ResponseClient> AddPhoneNumberService(AddPhoneNumberViewModel phoneNumberViewModel)
        {
            var userByPhone = await userManager.FindByPhoneAsync(phoneNumberViewModel.PhoneNumber);
            var appUser = await userManager.FindByIdAsync(phoneNumberViewModel.UserId.ToString());
            if (appUser == null) { return new("Không tìm thấy người dùng!", 400); }
            if (userByPhone != null && !userByPhone.Equals(appUser)) { return new("Số điện thoại đã được đăng ký", 400); }
            var otp = await otpManager.GenerateTotpUserAsync(appUser);
            // Gửi code đi tới điện thoại
            try {
                var dataCallApi = new { toPhone = "+" + phoneNumberViewModel.PhoneNumber, otp };
                var jsonData = JsonConvert.SerializeObject(dataCallApi);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await httpClient.PostAsync(messageApi, content);
            }
            catch (System.Exception) {
                Console.WriteLine("Không Gửi được tin nhắn");
            }
            await userManager.UpdateAsync(appUser);
            return new("Gửi Otp tới số điện thoại của bạn", 200);
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

        public async Task<ResponseClient> EditProfileAsync(EditExtraProfileViewModel editExtraProfile)
        {
            var appUser = await userManager.FindByIdAsync(editExtraProfile.UserId.ToString());
            if (appUser is null) { return new("Không tìm thấy người dùng", 404); }
            if (!string.IsNullOrWhiteSpace(editExtraProfile.UserName)) {
                var findUserByNameInRequest = await userManager.FindByNameAsync(editExtraProfile.UserName.ToString());
                if (appUser == findUserByNameInRequest || findUserByNameInRequest != null) { return new("xxx", 202); }
                var result = await userManager.SetUserNameAsync(appUser, editExtraProfile.UserName);
                if (!result.Succeeded) { return new("", 202); }
            }
            appUser.EditProfile(editExtraProfile.Sex, editExtraProfile.DateOfBirth, editExtraProfile.Job);
            await userManager.UpdateAsync(appUser);
            return new("Thay đổi thông tin thành công", 200);
        }
        public async Task<ResponseClient> VerifyPhoneNumberService(VerifyPhoneNumberViewModel verifyPhoneNumber)
        {
            var appUser = await userManager.FindByIdAsync(verifyPhoneNumber.UserId.ToString());
            if (appUser is null) { return new("Không tìm thấy người dùng", 404); }
            var result = await otpManager.CheckOtpAsync(appUser, verifyPhoneNumber.Code.ToString());
            if (!result.Succeeded) { return new(result.Errors.SingleOrDefault()?.Description, 200, false); }
            //Set cho Số điện thoại xác thực
            await userManager.SetPhoneNumberAsync(appUser, verifyPhoneNumber.PhoneNumber);
            var token = await userManager.GenerateChangePhoneNumberTokenAsync(appUser, verifyPhoneNumber.PhoneNumber);
            await userManager.ChangePhoneNumberAsync(appUser, verifyPhoneNumber.PhoneNumber, token);
            return new("Xác thực thành công!", 200, true);
        }
        public async Task<ApplicationUser> GetUserInfomation(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user is null) { return null; }
            return user;
        }
    }
}
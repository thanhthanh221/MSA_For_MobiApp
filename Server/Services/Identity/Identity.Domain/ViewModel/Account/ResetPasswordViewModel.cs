using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Account
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
        public string ConfirmPassword { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Email { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(100, ErrorMessage = "{0} phải dài từ {2} đến {1} ký tự.", MinimumLength = 3)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Password { get; set; }
    }
}
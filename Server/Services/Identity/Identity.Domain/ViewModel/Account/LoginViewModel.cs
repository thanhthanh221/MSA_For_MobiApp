using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

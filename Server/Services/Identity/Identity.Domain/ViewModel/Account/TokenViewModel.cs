using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Account
{
    public class TokenViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string AccessToken { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string RefreshToken { get; set; }
    }
}

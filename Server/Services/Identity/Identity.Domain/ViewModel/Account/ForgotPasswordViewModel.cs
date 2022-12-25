using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
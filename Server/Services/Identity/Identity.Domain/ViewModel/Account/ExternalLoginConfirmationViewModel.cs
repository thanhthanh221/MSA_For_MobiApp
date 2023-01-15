using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        [EmailAddress(ErrorMessage = "Phải đúng định dạng email")]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Provider { get; set; }
        [Required]
        public string ProviderKey { get; set; }
    }
}

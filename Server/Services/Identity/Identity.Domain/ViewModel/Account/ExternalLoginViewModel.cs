using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        public string Provider { get; set; }
        [Required]
        public string ProviderKey { get; set; }
    }
}
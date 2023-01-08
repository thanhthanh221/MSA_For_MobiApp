using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Manage
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
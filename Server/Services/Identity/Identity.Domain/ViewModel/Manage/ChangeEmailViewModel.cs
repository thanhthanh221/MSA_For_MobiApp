using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Manage
{
    public class ChangeEmailViewModel
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string NewEmail { get; set; }
    }
}

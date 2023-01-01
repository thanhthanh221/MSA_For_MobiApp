using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.ViewModel.Manage
{
    public class EditExtraProfileViewModel
    {
        [Required]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Job { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Message.ViewModel;

public class SmsOtpViewModel
{
    [Required]
    [Phone]
    public string ToPhone { get; set; }
    [Required]
    [MaxLength(4)]
    [MinLength(4)]
    public string Otp { get; set; }
}

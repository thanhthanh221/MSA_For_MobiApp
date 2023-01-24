using Message.ViewModel;

namespace Message.Interfaces
{
    public interface ISendMailService
    {
        Task SendMail(SendMailViewModel model);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}

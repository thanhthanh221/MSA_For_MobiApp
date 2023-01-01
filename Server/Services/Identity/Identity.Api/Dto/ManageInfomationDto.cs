using Identity.Domain.Model;

namespace Identity.Api.Dto
{
    public class ManageInfomationDto
    {
        public ManageInfomationDto(Guid id,
                                   string userName,
                                   EmailInfomation emailInfomation,
                                   PhoneInfomation phoneInfomation,
                                   bool? sex,
                                   DateTime? dateOfBirth,
                                   string job)
        {
            Id = id;
            UserName = userName;
            EmailInfomation = emailInfomation;
            PhoneInfomation = phoneInfomation;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            Job = job;
        }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public EmailInfomation EmailInfomation { get; private set; }
        public PhoneInfomation PhoneInfomation { get; private set; }
        public bool? Sex { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public string Job { get; private set; }

        public static ManageInfomationDto ConvertAppUserToDto(ApplicationUser appUser)
        {
            EmailInfomation email = new(appUser.Email, appUser.EmailConfirmed);
            PhoneInfomation phone = new(appUser.PhoneNumber, appUser.PhoneNumberConfirmed);
            ManageInfomationDto manageInfomationDto = new(appUser.Id, appUser.UserName, email, phone, appUser.Sex, appUser.DateOfBirth, appUser.Job);
            return manageInfomationDto;
        }
    }
    public class EmailInfomation
    {
        public EmailInfomation(string email, bool emailConfirmed)
        {
            Email = email;
            EmailConfirmed = emailConfirmed;
        }

        public string Email { get; private set; }
        public bool EmailConfirmed { get; private set; }
    }
    public class PhoneInfomation
    {
        public PhoneInfomation(string phone, bool phoneConfirmed)
        {
            Phone = phone;
            PhoneConfirmed = phoneConfirmed;
        }

        public string Phone { get; private set; }
        public bool PhoneConfirmed { get; private set; }
    }
}

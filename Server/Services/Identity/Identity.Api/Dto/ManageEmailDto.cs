namespace Identity.Api.Dto
{
    public class ManageEmailDto
    {
        public ManageEmailDto(string email, bool emailConfirmed)
        {
            Email = email;
            EmailConfirmed = emailConfirmed;
        }

        public string Email { get; private set; }
        public bool EmailConfirmed { get; private set; }
    }
}
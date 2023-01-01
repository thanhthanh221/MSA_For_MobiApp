using Identity.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Identity.Domain.IdentityConfig
{
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager(IUserStore<ApplicationUser> store,
                           IOptions<IdentityOptions> optionsAccessor,
                           IPasswordHasher<ApplicationUser> passwordHasher,
                           IEnumerable<IUserValidator<ApplicationUser>> userValidators,
                           IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
                           ILookupNormalizer keyNormalizer,
                           IdentityErrorDescriber errors,
                           IServiceProvider services,
                           ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
        public async Task<ApplicationUser> FindByPhoneAsync(string Phone)
        {
            if (Phone.Length != 10) { return null; }
            var appUser = await Users.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(Phone));
            return appUser;
        }
    }
}
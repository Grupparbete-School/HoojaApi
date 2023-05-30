using HoojaApi.Data;
using HoojaApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HoojaApi.CustomIdentity
{
    public class CustomUserManager : UserManager<User>
    {
        private readonly DbContextOptions<HoojaApiDbContext> options;

        public CustomUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger,
        DbContextOptions<HoojaApiDbContext> _options)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer,
            errors, services, logger)
        {
            options = _options;
        }
    }
}

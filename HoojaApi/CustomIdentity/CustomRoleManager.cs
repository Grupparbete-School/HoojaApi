using Microsoft.AspNetCore.Identity;
using System.Data;

namespace HoojaApi.CustomIdentity
{
    public class CustomRoleManager : RoleManager<IdentityRole<int>>
    {
        public CustomRoleManager(IRoleStore<IdentityRole<int>> store, IEnumerable<IRoleValidator<IdentityRole<int>>> roleValidators,
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<IdentityRole<int>>> logger)
        : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}

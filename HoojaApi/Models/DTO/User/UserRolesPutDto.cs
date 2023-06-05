namespace HoojaApi.Models.DTO.User
{
    public class UserRolesPutDto
    {
        public bool EmailConfirmed { get; set; }
        public IEnumerable<string>? Roles { get; set; } //list of roles
    }
}

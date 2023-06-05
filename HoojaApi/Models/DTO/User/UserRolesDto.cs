namespace HoojaApi.Models.DTO.User
{
    public class UserRolesDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public IEnumerable<string>? Roles { get; set; } //list of roles
    }
}

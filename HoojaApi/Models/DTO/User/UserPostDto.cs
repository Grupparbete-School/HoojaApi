namespace HoojaApi.Models.DTO.User
{
    public class UserPostDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string SecurityNumber { get; set; }
        public string PasswordHash { get; set; }
    }

}

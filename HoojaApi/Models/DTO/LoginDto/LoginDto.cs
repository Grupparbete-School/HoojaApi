using System.ComponentModel.DataAnnotations;

namespace HoojaApi.Models.DTO.LoginDto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

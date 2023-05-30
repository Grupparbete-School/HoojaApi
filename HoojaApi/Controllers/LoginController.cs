using HoojaApi.CustomIdentity;
using HoojaApi.Models;
using HoojaApi.Models.DTO.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CustomUserManager userManager;
        private readonly SignInManager<User> signInManager;

        public LoginController(SignInManager<User> _signInManager, CustomUserManager _userManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await userManager.FindByEmailAsync(loginDto.Email);

            if(user != null)
            {
                var passCheck = await userManager.CheckPasswordAsync(user, loginDto.Password);
                if (passCheck)
                {
                    var loginUser = await signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);

                    if (loginUser.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(user);
                        var token = GenerateJwtToken(user, roles);
                        return Ok(new { Token = token });
                    }
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

        //viktigt att denna sätts till private
        private string GenerateJwtToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = Environment.GetEnvironmentVariable("ISSUER");
            var audience = Environment.GetEnvironmentVariable("AUDIENCE");
            var expires = DateTime.UtcNow.AddHours(double.Parse("5"));

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

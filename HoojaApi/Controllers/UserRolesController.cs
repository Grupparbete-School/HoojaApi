using HoojaApi.CustomIdentity;
using HoojaApi.Models;
using HoojaApi.Models.DTO.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoojaApi.Controllers
{
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly CustomUserManager _userManager;
        private readonly CustomRoleManager _roleManager;

        public UserRolesController(CustomUserManager userManager, CustomRoleManager roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("api/userRoles")]
        public async Task<IActionResult> GetAllUserRoles()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesDto>();
            foreach (User user in users)
            {
                var thisViewModel = new UserRolesDto();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.EmailConfirmed = user.EmailConfirmed;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return Ok(userRolesViewModel);
        }

        private async Task<List<string>> GetUserRoles(User user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }


        [HttpGet]
        [Route("api/userRoles/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with id: {userId} cannot be found");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var userRolesViewModel = new UserRolesDto
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailConfirmed = user.EmailConfirmed,
                Roles = userRoles.ToList()
            };

            return Ok(userRolesViewModel);
        }

        //[HttpPost]
        //[Route("api/userRoles/Manage/{userId}")]
        //public async Task<IActionResult> ManageUserRoles(string userId, [FromBody] string newRole)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    // Remove user from existing roles
        //    var roles = await _userManager.GetRolesAsync(user);
        //    var result = await _userManager.RemoveFromRolesAsync(user, roles);
        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Cannot remove user's existing roles");
        //        return BadRequest(ModelState);
        //    }

        //    // Add user to the new role
        //    result = await _userManager.AddToRoleAsync(user, newRole);
        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Cannot add selected role to user");
        //        return BadRequest(ModelState);
        //    }

        //    return Ok();
        //}

        [HttpPost]
        [Route("api/userRoles/Manage/{userId}")]
        public async Task<IActionResult> ManageUserRoles(string userId, [FromBody] UserRolesPutDto userRolesPutDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            // Remove user from existing roles
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user's existing roles");
                return BadRequest(ModelState);
            }

            // Add user to the new roles
            result = await _userManager.AddToRolesAsync(user, userRolesPutDto.Roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return BadRequest(ModelState);
            }

            // Set EmailConfirmed
            user.EmailConfirmed = userRolesPutDto.EmailConfirmed;

            // Update the user
            result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Failed to update user");
                return BadRequest(ModelState);
            }

            // Return success message
            return Ok("User roles and email confirmation managed successfully.");
        }



    }
}


using System.Net.Mail;
using HoojaApi.CustomIdentity;
using HoojaApi.Data;
using HoojaApi.Models;
using HoojaApi.Models.DTO.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly HoojaApiDbContext _context;
        private readonly CustomUserManager _customUserManager;
        public CustomerController(HoojaApiDbContext context, CustomUserManager customUserManager)
        {
            _context = context;
            _customUserManager = customUserManager;
        }

        // GET: api/<CustomerController>
        //[HttpGet("GetAllCustomer")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Employee")]
        //public async Task<ActionResult<IEnumerable<User>>> GetAllCustomer()
        //{
        //    var customers = await _context.Users.ToListAsync();
        //    return Ok(customers);
        //}

        [HttpGet("GetAllUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        public async Task<ActionResult<IEnumerable<User>>> GetAllCustomer()
        {
            var customers = await _customUserManager.Users.ToListAsync();
            return Ok(customers);
        }

        [HttpGet("GetUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUser(string userId)
        {
            var user = await _customUserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        //// GET api/<CustomerController>/5
        //[HttpGet("Customer-By{id}")]
        //public async Task<ActionResult<IEnumerable<User>>> GetAllCustomer(int id)
        //{
        //    var customers = await _context.Users.FindAsync(id);

        //    if (customers == null)
        //    {
        //        return NotFound($"No customer with id: {id} found.");
        //    }
        //    return Ok(customers);
        //}

        // POST api/<CustomerController>
        //[HttpPost]
        //public async Task<ActionResult> AddCustomer([FromBody] User customer)
        //{
        //    _context.Users.Add(customer);
        //    await _context.SaveChangesAsync();

        //    return Ok(customer);
        //}

        [HttpPost("AddNewUser")]
        public async Task<ActionResult<UserPostDto>> AddUser([FromBody] UserPostDto createUserDto)
        {
            // Map the properties from the DTO to your internal model or perform any necessary validation

            var createUser = new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                UserName = createUserDto.UserName,
                PasswordHash = createUserDto.PasswordHash,
                Email = createUserDto.Email,
                SecurityNumber = createUserDto.SecurityNumber,
                EmailConfirmed = true,
                FK_AddressId = 2,
            };

                createUser.PasswordHash = _customUserManager.PasswordHasher.HashPassword(createUser, createUser.PasswordHash);

                var createUserResult = await _customUserManager.CreateAsync(createUser);

                await _customUserManager.UpdateSecurityStampAsync(createUser);
                await _customUserManager.AddToRoleAsync(createUser, "Customer");

                return Ok(createUserResult);
        }

        [HttpPut("EditUser/{userId}")]
        public async Task<IActionResult> EditUser(string userId, [FromBody] UserPostDto updateUserDto)
        {
            var user = await _customUserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            // Update the properties of the user based on the received DTO
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.UserName = updateUserDto.UserName;
            user.Email = updateUserDto.Email;
            user.SecurityNumber = updateUserDto.SecurityNumber;

            var updateUserResult = await _customUserManager.UpdateAsync(user);
            if (!updateUserResult.Succeeded)
            {
                // Handle the update failure, return an appropriate response
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update user.");
            }

            return NoContent();
        }


        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _customUserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var deleteUserResult = await _customUserManager.DeleteAsync(user);
            if (!deleteUserResult.Succeeded)
            {
                // Handle the delete failure, return an appropriate response
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete user.");
            }

            return NoContent();
        }


        // PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult<User>> UpdateCustomer(int id, [FromBody] User customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customer).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return Ok(customer);
        //}

        // DELETE api/<CustomerController>/5
        //[HttpDelete("Delete-Customer{id}")]
        //public async Task<ActionResult> DeleteCustomer(int id)
        //{
        //    var customer = await _context.Users.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return Ok($"Customer with {id} deleted successfully");
        //}
    }
}

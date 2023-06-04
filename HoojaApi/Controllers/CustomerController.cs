using HoojaApi.Data;
using HoojaApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly HoojaApiDbContext _context;

        public CustomerController(HoojaApiDbContext context)
        {
            _context = context;
        }

        // GET: api/<CustomerController>
        [HttpGet("GetAllCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllCustomer()
        {
            var customers = await _context.Users.ToListAsync();
            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("Customer-By{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllCustomer(int id)
        {
            var customers = await _context.Users.FindAsync(id);

            if (customers == null)
            {
                return NotFound($"No customer with id: {id} found.");
            }
            return Ok(customers);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> AddCustomer([FromBody] User customer)
        {
            _context.Users.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateCustomer(int id, [FromBody] User customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("Delete-Customer{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Users.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Users.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok($"Customer with {id} deleted successfully");
        }
    }
}

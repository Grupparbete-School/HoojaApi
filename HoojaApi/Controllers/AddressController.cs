using HoojaApi.Data;
using HoojaApi.Models;
using HoojaApi.Models.RelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoojaApi.Controllers
{
    public class AddressController : Controller
    {
        private readonly HoojaApiDbContext _context;

        public AddressController(HoojaApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Address>>> GetAllEmployee()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return Ok(addresses);
        }

        [HttpGet("GetAllAddress{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Address>>> GetAllEmployee(int id)
        {
            var addresses = await _context.Addresses.FindAsync(id);
            if(addresses == null)
            {
                return NotFound($"No address with id: {id} found");
            }
            return Ok(addresses);
        }

        [HttpPost("CreateAddress")]
        public async Task<ActionResult<Address>> CreateAddress([FromBody] Address address)
        {
            if(address == null)
            {
                return BadRequest();
            }

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Address created succesfully", address });
        }

        [HttpPut("UpdateAddress{id}")]
        public async Task<ActionResult<Address>> UpdateAddress(int id, [FromBody] Address address)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            if (id != address.AddressId)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new {message = $"Address with id: {id} updated succesfully", address});
        }

        [HttpDelete("DeleteAddress")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if(address == null)
            {
                return BadRequest();
            }
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return Ok($" Address with {id} deleted successfully");
        }
    }
}

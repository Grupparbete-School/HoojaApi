//using HoojaApi.Data;
//using HoojaApi.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HoojaApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : Controller
//    {
//        private readonly HoojaApiDbContext _context;

//        public CustomerController(HoojaApiDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/<CustomerController>
//        [HttpGet("GetAllCustomer")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
//        {
//            var customers = await _context.Customers.ToListAsync();
//            return Ok(customers);
//        }

//        // GET api/<CustomerController>/5
//        [HttpGet("Customer-By{id}")]
//        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer(int id)
//        {
//            var customers = await _context.Customers.FindAsync(id);

//            if (customers == null)
//            {
//                return NotFound($"No customer with id: {id} found.");
//            }
//            return Ok(customers);
//        }

//        // POST api/<CustomerController>
//        [HttpPost]
//        public async Task<ActionResult> AddCustomer([FromBody] Customer customer)
//        {
//            _context.Customers.Add(customer);
//            await _context.SaveChangesAsync();

//            return Ok(customer);
//        }

//        // PUT api/<CustomerController>/5
//        [HttpPut("{id}")]
//        public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer customer)
//        {
//            if (id != customer.CustomerId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(customer).State = EntityState.Modified;
//            await _context.SaveChangesAsync();

//            return Ok(customer);
//        }

//        // DELETE api/<CustomerController>/5
//        [HttpDelete("Delete-Customer{id}")]
//        public async Task<ActionResult> DeleteCustomer(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            _context.Customers.Remove(customer);
//            await _context.SaveChangesAsync();

//            return Ok($"Customer with {id} deleted successfully");
//        }
//    }
//}

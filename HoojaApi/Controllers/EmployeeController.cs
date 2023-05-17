using HoojaApi.Data;
using HoojaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly HoojaApiDbContext _context;

        public EmployeeController(HoojaApiDbContext context)
        {
            _context = context;
        }

        // GET: api/<EmployeeController>
        [HttpGet("GetAllEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }


        // GET api/<EmployeeController>/5
        [HttpGet("Employee-By{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee(int id)
        {
            var employees = await _context.Employees.FindAsync(id);

            if(employees == null)
            {
                return NotFound($"No employee with id: {id} found.");
            }
            return Ok(employees);
        }

        // POST api/<EmployeeController>
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult> AddEmployee([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

           return Ok(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if(id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("Delete-Employee{id}")]
        public async Task<ActionResult> DeleteEmoloyee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok($"Employee with {id} deleted successfully");
        }
    }
}

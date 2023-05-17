﻿using HoojaApi.Data;
using HoojaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly HoojaApiDbContext _context;

        public ProductController(HoojaApiDbContext context)
        {
            _context = context;
        }

         // GET: api/<ProductController>
        [HttpGet("GetAllProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProcuct()
        {
           var products = await _context.Products.ToListAsync();
           return Ok(products);
        }


        // GET api/<ProductController>/5
        [HttpGet("Product-By{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound($"No employee with id: {id} found.");
            }
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost("Create-Product")]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
           _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

           _context.Entry(product).State = EntityState.Modified;
           await _context.SaveChangesAsync();

            return Ok(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("Delete-Product{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok($"Product with {id} deleted successfully");
        }
    }
}
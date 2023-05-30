using HoojaApi.Data;
using HoojaApi.Models;
using HoojaApi.Models.DTO.ProductDto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<ActionResult> AddProduct(AddProductDto newProduct)
        {
            var product = new Product
            {
                ProductName = newProduct.ProductName,
                ProductDescription = newProduct.ProductDescription,
                Price = newProduct.Price,
                QuantityStock = newProduct.QuantityStock,
                ProductPicture = newProduct.ProductPicture,
                FK_ProductTypeId = newProduct.FK_ProductTypeId,
            };

           _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] ProductPUTDto product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            var existingProduct = await _context.Products.FindAsync(product.ProductId);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductDescription = product.ProductDescription;
            existingProduct.Price = product.Price;
            existingProduct.QuantityStock = product.QuantityStock;
            existingProduct.ProductPicture = product.ProductPicture;
            existingProduct.FK_ProductTypeId = product.ProductTypeId;

            var check = _context.Products.Update(existingProduct);

            var check2 = await _context.SaveChangesAsync();

            return Ok(existingProduct);
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

        [HttpGet("GetProductType")]
        public async Task<ActionResult> GetProductType()
        {
            var productType = await _context.ProductTypes.ToListAsync();
            if (productType == null)
            {
                return NotFound();
            }

            return Ok(productType);
        }
    }
}

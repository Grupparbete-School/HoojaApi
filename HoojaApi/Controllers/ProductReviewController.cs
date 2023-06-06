using HoojaApi.Data;
using HoojaApi.Models.DTO.ProductReviewDto;
using HoojaApi.Models.RelationTables;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductReviewController : ControllerBase
    {
        private readonly HoojaApiDbContext _context;
        public ProductReviewController(HoojaApiDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProductReviewController>
        [HttpGet("GetAllReviews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductReviewGetDto>>> GetAllReviews()
        {
            try
            {
                var productReviews = await _context.ProductReviews
                    .Include(pr => pr.Products)
                    .Select(pr => new ProductReviewGetDto
                    {
                        ReviewId = pr.ProductReviewId,
                        Review = pr.Review,
                        Rating = pr.Rating,
                        FK_ProductId = pr.FK_ProductId,
                        ProductName = pr.Products.ProductName,
                        CustomerName = pr.CustomerName,
                        ReviewOfDate = pr.ReviewOfDate,
                    })
                    .ToListAsync();

                return Ok(productReviews);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's error handling strategy
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the reviews");
            }
        }


        // GET api/<ProductReviewController>/5
        //Söker review efter produktID för det kan finnas flera review för samma produkt
        [HttpGet("GetAllReviews/ByProductId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductReviewGetDto>>> GetAllReviewsById(int id)
        {
            try
            {
                var productReviews = await _context.ProductReviews
                    .Include(pr => pr.Products)
                    .Where(pr => pr.FK_ProductId == id)
                    .Select(pr => new ProductReviewGetDto
                    {
                        ReviewId = pr.ProductReviewId,
                        Review = pr.Review,
                        Rating = pr.Rating,
                        FK_ProductId = pr.FK_ProductId,
                        ProductName = pr.Products.ProductName,
                        CustomerName = pr.CustomerName,
                        ReviewOfDate = pr.ReviewOfDate,
                    })
                    .ToListAsync();

                if (productReviews.Count == 0)
                {
                    return NotFound($"No product with id: {id} found. You need to create a review.");
                }

                return Ok(productReviews);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's error handling strategy
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the reviews");
            }
        }

        // GET api/<ProductReviewController>/5
        //Söker review efter reviewID för att hitta specific review
        [HttpGet("GetAllReviews/ByReviewId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductReviewGetDto>>> GetAllReviewsByReviewId(int id)
        {
            try
            {
                var productReviews = await _context.ProductReviews
                    .Include(pr => pr.Products)
                    .Where(pr => pr.ProductReviewId == id)
                    .Select(pr => new ProductReviewGetDto
                    {
                        ReviewId = pr.ProductReviewId,
                        Review = pr.Review,
                        Rating = pr.Rating,
                        FK_ProductId = pr.FK_ProductId,
                        ProductName = pr.Products.ProductName,
                        CustomerName = pr.CustomerName,
                        ReviewOfDate = pr.ReviewOfDate,
                    })
                    .ToListAsync();

                if (productReviews.Count == 0)
                {
                    return NotFound($"No product with id: {id} found. You need to create a review.");
                }

                return Ok(productReviews);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's error handling strategy
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the reviews");
            }
        }


        // POST api/<ProductReviewController>
        [HttpPost("AddProductReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductReviewPostDto>> CreateProductReview([FromBody] ProductReviewPostDto createReview)
        {
            try
            {
                if (createReview == null)
                {
                    return BadRequest("Invalid review data");
                }

                var newReview = new ProductReview
                {
                    FK_ProductId = createReview.FK_ProductId,
                    Review = createReview.Review,
                    Rating = createReview.Rating,
                    CustomerName = createReview.CustomerName,
                };

                _context.ProductReviews.Add(newReview);
                await _context.SaveChangesAsync();

                return Ok("Successfully created review");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's error handling strategy
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the review");
            }
        }


        // PUT api/<ProductReviewController>/5
        //Update använder sig av ReviewId vid sökning vilken review som ska uppdateras,
        //det för annars går det inte uppdatera specifik review 
        //när det finns flera review med samma produkt.
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("UpdateProductReview/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // Optional: Specifies the success response type
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Optional: Specifies the bad request response type
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Optional: Specifies the not found response type
        public async Task<ActionResult<ProductReviewPutDto>> UpdateProductReview(int id, [FromBody] ProductReviewPutDto updateReview)
        {
            if (id != updateReview.ReviewId)
            {
                return BadRequest("Invalid review ID.");
            }

            try
            {
                var existingReview = await _context.ProductReviews.FindAsync(updateReview.ReviewId);

                if (existingReview == null)
                {
                    return NotFound("Review not found.");
                }

                existingReview.Review = updateReview.Review;
                existingReview.Rating = updateReview.Rating;
                existingReview.ReviewOfDate = updateReview.ReviewOfDate;
                existingReview.CustomerName = updateReview.CustomerName;

                _context.ProductReviews.Update(existingReview);
                await _context.SaveChangesAsync();

                return Ok($"Successfully updated review with ID: {id}");
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an appropriate response.
                // You can customize the error message based on the exception if needed.
                return StatusCode(500, "An error occurred while updating the review.");
            }
        }


        // DELETE api/<ProductReviewController>/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("DeleteProductReview/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteReview(int id)
        {
            try
            {
                var review = await _context.ProductReviews.FindAsync(id);

                if (review == null)
                {
                    return NotFound();
                }

                _context.ProductReviews.Remove(review);
                await _context.SaveChangesAsync();

                return Ok($"Review with id: {id} deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's error handling strategy
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the review");
            }
        }

    }
}

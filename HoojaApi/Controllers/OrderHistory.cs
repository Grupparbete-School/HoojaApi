using HoojaApi.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoojaApi.Models;
using HoojaApi.Models.RelationTables;
using HoojaApi.Models.DTO.OrderHistoryDto;

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : Controller
    {
        private readonly HoojaApiDbContext _context;
        public OrderHistoryController(HoojaApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetOrderHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderHistoryGetDto>>> GetAllOrderHistory()
        {
            var orderHistory = await _context.OrderHistorys
                .Include(o => o.Orders)
                .Include(o => o.Products)
                .Include(o => o.Products.ProductTypes)
                .Include(o => o.Products.CampaignCodes)
                .Include(o => o.Orders.Customers)
                .Include(o => o.Orders.Customers.Addresses)
                .Select( o => new OrderHistoryGetDto
                {
                    OrderId = o.Orders.OrderId,
                    OrderComment = o.Orders.OrderComment,
                    OrderDate = o.Orders.OrderDate,
                    DeliveryDate = o.Orders.DeliveryDate,
                    ProductId = o.Products.ProductId,
                    ProductName = o.Products.ProductName,
                    ProductDescription = o.Products.ProductDescription,
                    Price = o.Products.Price,
                    QuantityStock = o.Products.QuantityStock,
                    ProductTypeId = o.Products.ProductTypes.ProductTypeId,
                    ProductTypeName = o.Products.ProductTypes.ProductTypeName,
                    CampaignCodeId = (int)o.Products.CampaignCodes.CampaignCodeId,
                    CampaignName = o.Products.CampaignCodes.CampaignName,
                    CustomerId = o.Orders.Customers.CustomerId,
                    FirstName = o.Orders.Customers.FirstName,
                    LastName = o.Orders.Customers.LastName,
                    FullName = o.Orders.Customers.FullName,
                    PhoneNumber = o.Orders.Customers.PhoneNumber,
                    SecurityNumber = o.Orders.Customers.SecurityNumber,
                    Email = o.Orders.Customers.Email,
                    AddressId = o.Orders.Customers.Addresses.AddressId,
                    Street = o.Orders.Customers.Addresses.Street,
                    PostalCode = o.Orders.Customers.Addresses.PostalCode,
                    City = o.Orders.Customers.Addresses.City,

                }).ToListAsync();

            return Ok(orderHistory);
        }

        

    }
}

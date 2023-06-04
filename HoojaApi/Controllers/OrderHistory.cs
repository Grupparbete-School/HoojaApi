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
    [ApiExplorerSettings(IgnoreApi = true)] //Gömmer apiEndpoint från swagger
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
                .Include(o => o.Orders.Users)
                .Include(o => o.Orders.Users.Addresses)
                .Select(o => new OrderHistoryGetDto
                {
                    OrderId = o.Orders.OrderId,
                    OrderComment = o.Orders.OrderComment,
                    OrderDate = o.Orders.OrderDate,
                    DeliveryDate = o.Orders.DeliveryDate,
                    ProductId = o.Products.ProductId,
                    Brand = o.Products.Brand,
                    ProductName = o.Products.ProductName,
                    ProductDescription = o.Products.ProductDescription,
                    Price = o.Products.Price,
                    QuantityStock = o.Products.QuantityStock,
                    Amount = o.Amount,
                    TotalPrice = o.TotalPrice,
                    ProductTypeId = o.Products.ProductTypes.ProductTypeId,
                    ProductTypeName = o.Products.ProductTypes.ProductTypeName,
                    CampaignCodeId = (int)o.Products.CampaignCodes.CampaignCodeId,
                    CampaignName = o.Products.CampaignCodes.CampaignName,
                    CustomerId = o.Orders.Users.Id,
                    FirstName = o.Orders.Users.FirstName,
                    LastName = o.Orders.Users.LastName,
                    FullName = o.Orders.Users.FullName,
                    PhoneNumber = o.Orders.Users.PhoneNumber,
                    SecurityNumber = o.Orders.Users.SecurityNumber,
                    Email = o.Orders.Users.Email,
                    AddressId = o.Orders.Users.Addresses.AddressId,
                    Street = o.Orders.Users.Addresses.Street,
                    PostalCode = o.Orders.Users.Addresses.PostalCode,
                    City = o.Orders.Users.Addresses.City,

                }).ToListAsync();

            return Ok(orderHistory);
        }

        [HttpGet("GetAllOrderHistoryById{id}")]
        public async Task<ActionResult<IEnumerable<OrderHistoryGetDto>>> GetAllOrderHistoryById(int id)
        {
            var orderHistory = await _context.OrderHistorys
                .Include(o => o.Orders)
                .Include(o => o.Products)
                .Include(o => o.Products.ProductTypes)
                .Include(o => o.Products.CampaignCodes)
                .Include(o => o.Orders.Users)
                .Include(o => o.Orders.Users.Addresses)
                .Where(o => o.FK_OrderId == id)
                .Select(o => new OrderHistoryGetDto
                {
                    OrderId = o.Orders.OrderId,
                    OrderComment = o.Orders.OrderComment,
                    OrderDate = o.Orders.OrderDate,
                    DeliveryDate = o.Orders.DeliveryDate,
                    ProductId = o.Products.ProductId,
                    Brand = o.Products.Brand,
                    ProductName = o.Products.ProductName,
                    ProductDescription = o.Products.ProductDescription,
                    Price = o.Products.Price,
                    Amount = o.Amount,
                    TotalPrice = o.TotalPrice,
                    QuantityStock = o.Products.QuantityStock,
                    ProductTypeId = o.Products.ProductTypes.ProductTypeId,
                    ProductTypeName = o.Products.ProductTypes.ProductTypeName,
                    CampaignCodeId = (int)o.Products.CampaignCodes.CampaignCodeId,
                    CampaignName = o.Products.CampaignCodes.CampaignName,
                    CustomerId = o.Orders.Users.Id,
                    FirstName = o.Orders.Users.FirstName,
                    LastName = o.Orders.Users.LastName,
                    FullName = o.Orders.Users.FullName,
                    PhoneNumber = o.Orders.Users.PhoneNumber,
                    SecurityNumber = o.Orders.Users.SecurityNumber,
                    Email = o.Orders.Users.Email,
                    AddressId = o.Orders.Users.Addresses.AddressId,
                    Street = o.Orders.Users.Addresses.Street,
                    PostalCode = o.Orders.Users.Addresses.PostalCode,
                    City = o.Orders.Users.Addresses.City,

                }).ToListAsync();

            return Ok(orderHistory);
        }
    }
}

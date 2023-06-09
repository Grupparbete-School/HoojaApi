﻿using HoojaApi.Data;
using HoojaApi.Models;
using HoojaApi.Models.DTO.OrderDto;
using HoojaApi.Models.RelationTables;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HoojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : Controller
    {
        private readonly HoojaApiDbContext _context;

        public OrderController(HoojaApiDbContext context)
        {
            _context = context;
        }

        // GET: api/<OrderController>
        [HttpGet("GetAllOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("Order-By{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder(int id)
        {
            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound($"No employee with id: {id} found.");
            }
            return Ok(orders);
        }

        //För kunder som inte är registrerade
        [HttpPost("AddOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddOrder([FromBody] OrderPostDto createOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newAddress = new Address
                {
                    Street = createOrder.Street,
                    PostalCode = createOrder.PostalCode,
                    City = createOrder.City,
                };

                _context.Addresses.Add(newAddress);
                await _context.SaveChangesAsync();

                var newAddressId = newAddress.AddressId;

                //var newCustomer = new User
                //{
                //    FirstName = createOrder.FirstName,
                //    LastName = createOrder.LastName,
                //    Email = createOrder.Email,
                //    FK_AddressId = newAddressId,
                //};

                //_context.Users.Add(newCustomer);
                //await _context.SaveChangesAsync();

                int newCustomerId = (int)createOrder.userId;

                var newOrder = new Order
                {
                    OrderComment = createOrder.OrderComment,
                    FK_CustomerId = newCustomerId,
                };

                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                int newOrderId = newOrder.OrderId;

                var newHistory = new OrderHistory
                {
                    FK_OrderId = newOrderId,
                    FK_ProductId = (int)createOrder.ProductId,
                };

                _context.OrderHistorys.Add(newHistory);
                await _context.SaveChangesAsync();

                return Ok("Order created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("Delete-Order{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok($"Order with {id} deleted successfully");
        }
    }
}

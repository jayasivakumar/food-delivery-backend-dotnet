using System.Security.Claims;
using FoodDeliveryApi.Data;
using FoodDeliveryApi.DTOs;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CreateOrderDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            decimal total = 0;
            var orderItems = new List<OrderItem>();

            foreach (var itemDto in dto.Items)
            {
                var menuItem = await _context.MenuItems.FindAsync(itemDto.MenuItemId);
                if (menuItem == null) return BadRequest($"Menu item {itemDto.MenuItemId} not found.");

                total += menuItem.Price * itemDto.Quantity;
                orderItems.Add(new OrderItem
                {
                    MenuItemId = menuItem.Id,
                    Quantity = itemDto.Quantity,
                    Price = menuItem.Price
                });
            }

            var order = new Order
            {
                UserId = userId,
                RestaurantId = dto.RestaurantId,
                TotalAmount = total,
                Items = orderItems
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var orders = await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.UserId == userId)
                .ToListAsync();

            return Ok(orders);
        }
    }
}
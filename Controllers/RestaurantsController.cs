using FoodDeliveryApi.Data;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RestaurantsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Restaurants.Include(r => r.MenuItems).ToListAsync());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return Ok(restaurant);
        }

        [HttpPost("{restaurantId}/menu")]
        [Authorize(Roles = "Admin,RestaurantOwner")]
        public async Task<IActionResult> AddMenuItem(int restaurantId, MenuItem item)
        {
            item.RestaurantId = restaurantId;
            _context.MenuItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using FoodDeliveryApi.Models;

namespace FoodDeliveryApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    }
}
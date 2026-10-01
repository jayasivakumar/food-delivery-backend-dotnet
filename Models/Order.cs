namespace FoodDeliveryApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // "Pending", "Preparing", "Delivered"
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        // Navigation property: One Order contains many OrderItems
        public List<OrderItem> Items { get; set; } = new();
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
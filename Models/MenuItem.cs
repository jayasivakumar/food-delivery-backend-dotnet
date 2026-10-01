namespace FoodDeliveryApi.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Foreign Key link back to Restaurant
        public int RestaurantId { get; set; }
    }
}
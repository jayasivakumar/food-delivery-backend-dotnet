namespace FoodDeliveryApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Navigation property: One Restaurant has many MenuItems
        public List<MenuItem> MenuItems { get; set; } = new();
    }
}
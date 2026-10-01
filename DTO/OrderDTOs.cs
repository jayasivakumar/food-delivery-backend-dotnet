namespace FoodDeliveryApi.DTOs
{
    public record OrderItemDto(int MenuItemId, int Quantity);
    public record CreateOrderDto(int RestaurantId, List<OrderItemDto> Items);
}
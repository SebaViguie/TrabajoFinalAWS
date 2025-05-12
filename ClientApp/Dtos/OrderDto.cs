namespace ClientApp.Dtos
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public List<OrderListItemDto> OrderItems { get; set; } = new List<OrderListItemDto>();

    }

    public class OrderListItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

namespace ClientApp.Dtos
{
    public class CustomerOrderDto
    {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; } = DateTime.UtcNow;
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public decimal TotalAmount { get; set; }
            public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}

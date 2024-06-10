namespace WebApplication4.TaskModels;

public class OrderDto
{
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public List<ProductOrderDto> Products { get; set; }
}

public class ProductOrderDto
{
    public int Id { get; set; }
    public int Amount { get; set; }
}

using WebApplication4.Models;

namespace WebApplication4.TaskModels;

public class GetClientOrders
{
    public int Clientorder { get; set; }
    public string ClientLastName { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? FufliledDateTime { get; set; }
    public string OrderStatus { get; set; }
    public List<InOrder> prarametsOrders { get; set; }
}

public class InOrder
{
    public string name { get; set; }
    public double price { get; set; }
    public int amount { get; set; }
}
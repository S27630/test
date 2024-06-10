using Microsoft.EntityFrameworkCore;
using WebApplication4.Contexts;
using WebApplication4.TaskModels;
using WebApplication4.Exceptions;

namespace WebApplication4.Service;

public interface IClientService
{
    Task<List<GetClientOrders>> GetByclientID(int id);
}

public class ClientService(DatabaseContext context) : IClientService
{
    public async Task<List<GetClientOrders>> GetByclientID(int id)
    {
        var result =  context.Orders
            .Where(e => e.Client.ClientID == id)
            .Select(e => new GetClientOrders
            {
                Clientorder = e.OrderID,
                ClientLastName = e.Client.ClientLastName,
                CreatedDateTime = e.OrderCreatedAt,
                FufliledDateTime = e.OrderFulfilledAt,
                OrderStatus = e.Status.StatusName,
                prarametsOrders = e.Product_Order.Select(e => new InOrder
                {
                    name = e.Product.ProductName,
                    price = e.Product.ProductPrice,
                    amount = e.Amount
                }).ToList()

            }).ToList();

        if (result is null)
        {
            throw new NotFound("chuj ci w dupe nie działa");
        }

        return result;
    }
}
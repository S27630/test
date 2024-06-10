using Microsoft.EntityFrameworkCore;
using WebApplication4.Contexts;
using WebApplication4.Models;
using WebApplication4.TaskModels;

namespace WebApplication4.Service;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(int clientId, OrderDto orderDto);
}

public class OrderService : IOrderService
{
    private readonly DatabaseContext _context;

    public OrderService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrderAsync(int clientId, OrderDto orderDto)
    {
        if (orderDto == null || orderDto.Products == null || !orderDto.Products.Any())
        {
            throw new ArgumentException("Invalid order data.");
        }

        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            throw new KeyNotFoundException("Client not found.");
        }

        var status = await _context.Status.FirstOrDefaultAsync(s => s.StatusName == "Utworzone");
        if (status == null)
        {
            throw new InvalidOperationException("Status 'Utworzone' not found.");
        }

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var order = new Order
            {
                ClientId = clientId,
                OrderCreatedAt = orderDto.CreatedAt,
                OrderFulfilledAt = orderDto.FulfilledAt,
                StatusId = status.StatusID
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var productDto in orderDto.Products)
            {
                var productOrder = new Product_Order
                {
                    OrderID = order.OrderID,
                    ProductID = productDto.Id,
                    Amount = productDto.Amount
                };
                _context.Product_Order.Add(productOrder);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return order;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
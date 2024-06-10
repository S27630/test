using Microsoft.EntityFrameworkCore;
using WebApplication4.Contexts;
using WebApplication4.Exceptions;
using WebApplication4.Service;
using WebApplication4.TaskModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/accounts/{accountID:int}", async (int accountID, IClientService service) =>
{
    try
    {
        return Results.Ok(await service.GetByclientID(accountID));
    }
    catch (NotFound e)
    {
        return Results.NotFound((object?)e.Message);
    }
});
app.MapPost("api/clients/{clientId:int}/orders", async (int clientId, OrderDto orderDto, IOrderService service) =>
{
    try
    {
        var order = await service.CreateOrderAsync(clientId, orderDto);
        return Results.Ok(order);
    }
    catch (ArgumentException e)
    {
        return Results.BadRequest(e.Message);
    }
    catch (KeyNotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
    catch (InvalidOperationException e)
    {
        return Results.BadRequest(e.Message);
    }
    catch (Exception e)
    {
        return Results.Problem(detail: e.Message, statusCode: 500, title: "An error occurred while processing the order.");
    }
});

app.Run();


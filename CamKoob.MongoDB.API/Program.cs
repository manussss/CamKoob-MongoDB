var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetConnectionString("MongoDB")));
builder.Services
    .AddScoped<IMongoDatabase>(provider => provider.GetRequiredService<IMongoClient>().GetDatabase("Orders"));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/v1/order", async (
    [FromServices] IOrderRepository orderRepository,
    Order order
) =>
{
    await orderRepository.CreateAsync(order);

    return Results.Created();
})
.WithOpenApi();

app.MapGet("/api/v1/order", async (
    [FromServices] IOrderRepository orderRepository
) =>
{
    var orders = await orderRepository.GetAsync();

    return Results.Ok(orders);
})
.WithOpenApi();

app.MapGet("/api/v1/order/{id}", async (
    [FromServices] IOrderRepository orderRepository,
    Guid id
) =>
{
    var order = await orderRepository.GetByIdAsync(id);

    if (order is null)
        return Results.NotFound();
    
    return Results.Ok(order);
})
.WithOpenApi();

await app.RunAsync();

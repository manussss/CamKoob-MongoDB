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

app.MapPost("/api/v1/order", () =>
{
    
})
.WithOpenApi();

app.MapGet("/api/v1/order", () =>
{
    
})
.WithOpenApi();

app.MapGet("/api/v1/order/{id}", () =>
{
    
})
.WithOpenApi();

await app.RunAsync();

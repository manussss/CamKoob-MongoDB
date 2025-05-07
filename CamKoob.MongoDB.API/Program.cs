var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using EcommerceApp.Application.Services;
using EcommerceApp.Application.Ports.In;
using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Adapters.Outbound.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependencies injection
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<IProductUseCase, ProductService>();

builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
//app.UseHttpsRedirection();

app.Run();
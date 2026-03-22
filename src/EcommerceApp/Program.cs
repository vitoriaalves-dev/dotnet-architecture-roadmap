using EcommerceApp.Application.Services;
using EcommerceApp.Application.Ports.In;
using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Infrastructure.Repositories;
using EcommerceApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependencies injection
builder.Services.AddOpenApi();

builder.Services.AddScoped<IProductRepository, SqlProductRepository>();
builder.Services.AddScoped<IProductUseCase, ProductService>();

builder.Services.AddScoped<IOrderRepository, SqlOrderRepository>();
builder.Services.AddScoped<IOrderUseCase, OrderService>();

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
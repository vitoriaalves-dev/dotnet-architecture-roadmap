using EcommerceApp.Application.Services;
using EcommerceApp.Application.Ports.In;
using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Infrastructure.Repositories;
using EcommerceApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration["Mongo:ConnectionString"]
    ?? throw new InvalidOperationException("Mongo connection string 'Mongo:ConnectionString' was not configured.");
var mongoDatabaseName = builder.Configuration["Mongo:Database"] ?? "ecommerce";

builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSingleton<IMongoClient>(_ =>
    new MongoClient(mongoConnectionString));

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoDatabaseName);
});

builder.Services.AddScoped<IOrderReportRepository, MongoOrderReportRepository>();

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
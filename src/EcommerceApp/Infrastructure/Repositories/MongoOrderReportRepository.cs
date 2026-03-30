using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Persistence.Mongo;
using MongoDB.Driver;

namespace EcommerceApp.Infrastructure.Repositories;

public class MongoOrderReportRepository : IOrderReportRepository
{
    private readonly IMongoCollection<OrderReportDocument> _collection;

    public MongoOrderReportRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<OrderReportDocument>("order_reports");
    }

    public void Save(Order order)
    {
        OrderReportDocument doc = new()
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            TotalItems = order.Items.Count,
            Items = order.Items.Select(i => new OrderItemReport
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };

        _collection.InsertOne(doc);
    }

    public IEnumerable<OrderReportDocument> GetAll()
        => _collection.Find(_ => true).ToList();
}
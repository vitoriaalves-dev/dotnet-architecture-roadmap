using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EcommerceApp.Infrastructure.Persistence.Mongo;

public class OrderReportDocument
{
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TotalItems { get; set; }
    public List<OrderItemReport> Items { get; set; } = new();
}

public class OrderItemReport
{
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
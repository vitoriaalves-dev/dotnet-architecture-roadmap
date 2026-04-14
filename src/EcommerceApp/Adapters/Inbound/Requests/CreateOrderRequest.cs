using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Inbound.Requests;

public class CreateOrderRequest
{
    public required List<OrderItem> Items { get; set; }
}


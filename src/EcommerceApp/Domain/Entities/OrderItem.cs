namespace EcommerceApp.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
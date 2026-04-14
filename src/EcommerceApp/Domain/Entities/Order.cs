using EcommerceApp.Domain.Exceptions;

namespace EcommerceApp.Domain.Entities;

public class Order
{
    private readonly List<OrderItem> _items = [];
    public Guid Id { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    private Order()
    {
        Id = Guid.NewGuid();
    }

    public static Order Create(IEnumerable<OrderItem> items)
    {
        if (items is null || !items.Any())
            throw new DomainException("Pedido deve possuir ao menos um item");

        Order order = new();

        foreach (OrderItem item in items)
            order.AddItem(item);

        return order;
    }

    public void AddItem(OrderItem item)
    {
        if (item.Quantity <= 0)
            throw new DomainException("Quantidade inválida");

        _items.Add(item);
    }
}
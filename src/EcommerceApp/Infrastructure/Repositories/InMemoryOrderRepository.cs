public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public IEnumerable<Order> GetAll() => _orders;

    public Order? GetById(Guid id) =>
        _orders.FirstOrDefault(o => o.Id == id);

    public void Add(Order order)
    {
        order.Id = Guid.NewGuid();
        _orders.Add(order);
    }
}
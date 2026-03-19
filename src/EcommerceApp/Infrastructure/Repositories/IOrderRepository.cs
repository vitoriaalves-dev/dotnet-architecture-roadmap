namespace EcommerceApp.Infrastructure.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    IEnumerable<Order> GetAll();
}
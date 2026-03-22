using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Adapters.Outbound.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    IEnumerable<Order> GetAll();
}
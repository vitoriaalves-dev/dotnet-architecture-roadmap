using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Ports.Out;

public interface IOrderRepository
{
    void Add(Order order);
    IEnumerable<Order> GetAll();
}
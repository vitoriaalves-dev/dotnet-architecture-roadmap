using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Ports.In;

public interface IOrderUseCase
{
    IEnumerable<Order> GetAll();
    Order Create(Order order);
}

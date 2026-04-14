using EcommerceApp.Domain.Entities;
using EcommerceApp.Inbound.Requests;

namespace EcommerceApp.Application.Ports.In;

public interface IOrderUseCase
{
    IEnumerable<Order> GetAll();
    Order Create(CreateOrderRequest createOrderRequest);
}

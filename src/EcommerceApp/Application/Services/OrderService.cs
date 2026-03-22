using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Order> GetAll() => _repository.GetAll();

    public Order Create(Order order)
    {
        _repository.Add(order);
        return order;
    }
}
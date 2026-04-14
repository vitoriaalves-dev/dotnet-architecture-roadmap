using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Domain.Entities;

using EcommerceApp.Application.Ports.In;
using EcommerceApp.Inbound.Requests;

namespace EcommerceApp.Application.Services;

public class OrderService : IOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderReportRepository _reportRepository;

    public OrderService(
        IOrderRepository orderRepository,
        IOrderReportRepository reportRepository)
    {
        _orderRepository = orderRepository;
        _reportRepository = reportRepository;
    }

    public Order Create(CreateOrderRequest createOrderRequest)
    {        
        Order order = Order.Create(createOrderRequest.Items);

        _orderRepository.Add(order);      // SQL
        _reportRepository.Save(order);    // Mongo
        return order;
    }

    public IEnumerable<Order> GetAll() => _orderRepository.GetAll();
}
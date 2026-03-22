using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Application.Services;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Inbound.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_orderService.GetAll());
    }

    [HttpPost]
    public IActionResult Post(Order order)
    {
        Order created = _orderService.Create(order);
        return Ok(created);
    }
}
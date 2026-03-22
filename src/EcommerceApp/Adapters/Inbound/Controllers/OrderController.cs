using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Application.Ports.In;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Inbound.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderUseCase _useCase;

    public OrderController(IOrderUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_useCase.GetAll());

    [HttpPost]
    public IActionResult Post(Order order)
    {
        Order created = _useCase.Create(order);
        return Ok(created);
    }
}
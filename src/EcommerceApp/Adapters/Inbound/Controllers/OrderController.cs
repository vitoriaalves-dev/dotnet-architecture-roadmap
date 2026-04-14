using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Application.Ports.In;
using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Inbound.Requests;

namespace EcommerceApp.Inbound.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderUseCase _useCase;
    private readonly IOrderReportRepository _reportRepository;

    public OrderController(IOrderUseCase useCase, IOrderReportRepository reportRepository)
    {
        _useCase = useCase;
        _reportRepository = reportRepository;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_useCase.GetAll());

    [HttpPost]
    public IActionResult Post(CreateOrderRequest createOrderRequest)
    {
        Order created = _useCase.Create(createOrderRequest);
        return Ok(created);
    }

    [HttpGet("reports")]
    public IActionResult GetReports()
    {
        return Ok(_reportRepository.GetAll());
    }
}
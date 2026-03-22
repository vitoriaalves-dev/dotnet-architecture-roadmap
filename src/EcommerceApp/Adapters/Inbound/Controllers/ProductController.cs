using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Application.Services;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Inbound.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.GetAll());

    [HttpPost]
    public IActionResult Post(Product product)
    {
        var created = _service.Create(product);
        return Ok(created);
    }
}
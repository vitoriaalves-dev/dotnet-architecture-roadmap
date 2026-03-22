using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Application.Services;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Inbound.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductUseCase _useCase;

    public ProductController(IProductUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_useCase.GetAll());

    [HttpPost]
    public IActionResult Post(Product product)
    {
        Product created = _useCase.Create(product);
        return Ok(created);
    }
}
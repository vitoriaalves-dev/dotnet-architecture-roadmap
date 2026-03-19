using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Repositories;

namespace EcommerceApp.Application.Services;
public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAll() => _repository.GetAll();

    public Product Create(Product product)
    {
        _repository.Add(product);
        return product;
    }
}
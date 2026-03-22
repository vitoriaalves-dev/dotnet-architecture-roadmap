using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Repositories;

namespace EcommerceApp.Infrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(Guid id) =>
        _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        product.Id = Guid.NewGuid();
        _products.Add(product);
    }
}
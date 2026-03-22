using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Ports.Out;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    void Add(Product product);
}
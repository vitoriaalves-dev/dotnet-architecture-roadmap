using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Adapters.Outbound.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    void Add(Product product);
}
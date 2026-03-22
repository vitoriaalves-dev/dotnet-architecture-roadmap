using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Ports.In;

public interface IProductUseCase
{
    IEnumerable<Product> GetAll();
    Product Create(Product product);
}
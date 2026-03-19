namespace EcommerceApp.Infrastructure.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    void Add(Product product);
}
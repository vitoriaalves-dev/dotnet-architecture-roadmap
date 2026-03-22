using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Repositories;

public class SqlProductRepository : IProductRepository
{
    private readonly EcommerceDbContext _context;

    public SqlProductRepository(EcommerceDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
        => _context.Products.AsNoTracking().ToList();

    public Product? GetById(Guid id)
        => _context.Products.Find(id);

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
}
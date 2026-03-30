using EcommerceApp.Application.Ports.Out;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Repositories;

public class SqlOrderRepository : IOrderRepository
{
    private readonly EcommerceDbContext _context;

    public SqlOrderRepository(EcommerceDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAll()
        => _context.Orders.Include(o => o.Items).AsNoTracking().ToList();

    public Order? GetById(Guid id)
        => _context.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == id);

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}
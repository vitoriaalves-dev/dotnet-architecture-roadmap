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
        => _context.Orders.AsNoTracking().ToList();

    public Order? GetById(Guid id)
        => _context.Orders.Find(id);

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}
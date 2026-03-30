using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Persistence.Mongo;

namespace EcommerceApp.Application.Ports.Out
{
    public interface IOrderReportRepository
    {
        void Save(Order order);
        IEnumerable<OrderReportDocument> GetAll();
    }
}
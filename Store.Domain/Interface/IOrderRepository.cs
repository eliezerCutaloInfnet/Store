using Store.Domain._shared;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Domain.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllByUserAsync(Guid userId);
    }
}

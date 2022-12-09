using Store.Domain._shared;
using Store.Domain.Entities;

namespace Store.Domain.Interface
{
    public interface IOrderProductRepository : IRepository<OrderProduct>
    {
        Task<IEnumerable<OrderProduct>> GetAllByOrderAsync(Guid orderId);
        Task<IEnumerable<OrderProduct>> GetAllAsync();
        Task Update(OrderProduct orderProduct);

    }
}

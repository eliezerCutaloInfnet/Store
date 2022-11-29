using Store.Domain.Entities;
using Store.Domain.Interface;
using Store.Infra.Data._shared;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}

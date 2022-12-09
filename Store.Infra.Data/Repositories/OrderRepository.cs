using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.Interface;
using Store.Infra.Data._shared;
using Store.Infra.Data.Context;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Store.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Order>> GetAllByUserAsync(Guid userId)
        {
            return await _dataset
                .AsNoTracking()
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

    }
}

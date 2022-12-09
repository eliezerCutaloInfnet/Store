using Microsoft.EntityFrameworkCore;
using Store.Domain._shared;
using Store.Domain.Entities;
using Store.Domain.Interface;
using Store.Infra.Data._shared;
using Store.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infra.Data.Repositories
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<OrderProduct>> GetAllByOrderAsync(Guid orderId)
        {
            return await _dataset
                .AsNoTracking()
                .Where(op => op.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderProduct>> GetAllAsync()
        {
            return await _dataset
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Update(OrderProduct orderProduct)
        {
            _dataset
                .Update(orderProduct);
            await _context.SaveChangesAsync();
        }

    }
}

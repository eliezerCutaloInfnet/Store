using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interface;
using Store.Infra.Data._shared;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _dataset.Where(x=> x.Name.Contains(name)).ToListAsync();
        }
    }
}

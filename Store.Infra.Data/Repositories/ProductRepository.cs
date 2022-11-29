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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _dataset
                .FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}

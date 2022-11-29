using Store.Domain._shared;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByNameAsync(string name);
    }
}

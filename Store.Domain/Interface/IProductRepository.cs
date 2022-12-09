using Store.Domain._shared;
using Store.Domain.Entities;

namespace Store.Domain.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchByNameAsync(string name);
    }

}

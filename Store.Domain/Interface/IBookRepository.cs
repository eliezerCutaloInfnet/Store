using Store.Domain._shared;
using Store.Domain.Entities;

namespace Store.Domain.Interface
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task DeleteAsync(Book book);
        Task<Book> GetByIsbnAsync(string isbn);
    }
}

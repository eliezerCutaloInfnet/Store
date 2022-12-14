using Microsoft.EntityFrameworkCore;
using Store.Domain._shared;
using Store.Domain.Entities;
using Store.Domain.Interface;
using Store.Infra.Data._shared;
using Store.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infra.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteAsync(Book book)
        {
            var track = _dataset.Attach(book);
            track.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<Book> GetByIsbnAsync(string isbn)
        {
            return await _dataset.FirstOrDefaultAsync(o => o.Isbn == isbn);
        }
    }
}

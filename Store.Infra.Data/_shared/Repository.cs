using Microsoft.EntityFrameworkCore;
using Store.Domain._shared;
using Store.Domain.Entities;
using Store.Infra.Data.Context;

namespace Store.Infra.Data._shared
{
    public class Repository<T> : IRepository<T> where T : Entity<T>
    {
        #region Protected fields

        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dataset;

        #endregion

        #region Constructor
        public Repository(AppDbContext context)
        {
            if(context== null) throw new ArgumentNullException("context");  
            _context = context;
            _dataset = _context.Set<T>();
        }
        #endregion


        public async Task AddAsync(T entity)
        {

            await _dataset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dataset
                .Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _dataset?.FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}

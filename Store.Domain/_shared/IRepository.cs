namespace Store.Domain._shared
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(Guid id);
        Task AddAsync(T entity);
    }
}

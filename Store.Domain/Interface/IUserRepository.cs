using Store.Domain._shared;
using Store.Domain.Entities;

namespace Store.Domain.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task Update(User user);
    }
}

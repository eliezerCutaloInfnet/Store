using Store.Domain._shared;

namespace Store.Domain.Entities
{
    public class User : Entity
    {
        protected IList<Order> _orders;
        public User(string? name, string? username, string? password, string? email)
        {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            _orders = new List<Order>();
        }

        protected User()
        {
            _orders = new List<Order>();
        }

        public string? Name { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }
        public string? Email { get; private set; }
        public IList<Order> Orders => _orders;
    }
}

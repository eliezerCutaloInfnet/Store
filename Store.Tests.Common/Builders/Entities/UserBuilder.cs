using Bogus;
using Store.Domain.Entities;

namespace Store.Tests.Common.Builders.Entities
{
    public class UserBuilder
    {
        private string? _name;
        private string? _username;
        private string? _email;
        private string? _password;
        public static UserBuilder New()
        {
            var faker = new Faker();
            return new UserBuilder
            {
                _name = faker.Name.FirstName(),
                _username = faker.Internet.UserName(),
                _email = faker.Person.Email,
                _password = faker.Internet.Password(20)
            };
        }

        public UserBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserBuilder WithUserName(string userName)
        {
            _username = userName;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public User Build()
        {
            return new User(_name, _username, _password, _email);
        }
    }
}

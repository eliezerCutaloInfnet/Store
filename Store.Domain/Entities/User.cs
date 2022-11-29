using FluentValidation;
using Store.Domain._shared;

namespace Store.Domain.Entities
{
    public class User : Entity<User>
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

        public override bool IsValid()
        {
            ValidateName();
            ValidateUsername();
            ValidatePassword();

            AddErrors(Validate(this));

            return ValidationResult.IsValid;
        }

        #region Private Methods
        private void ValidateName()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(5, 100).WithMessage("Name must contain between 5 and 100 characters");
        }

        private void ValidateUsername()
        {
            RuleFor(d => d.Username)
                .NotEmpty().WithMessage("User Name cannot be empty")
                .Length(5, 100).WithMessage("User Name must contain between 5 and 100 characters");
        }

        private void ValidatePassword()
        {
            RuleFor(d => d.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .Length(5, 100).WithMessage("Password must contain between 5 and 100 characters");
        }
        #endregion Private Methods
    }
}

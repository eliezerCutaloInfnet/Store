using FluentValidation;
using Store.Domain._shared;

namespace Store.Domain.Entities
{
    public class Product : Entity<Product>
    {
        #region Protected Fields

        protected IList<OrderProduct> _orderProducts;

        #endregion Protected Fields

        #region Public Constructors
        public Product(string? name, string? description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
            _orderProducts = new List<OrderProduct>();
        }

        #endregion Public Constructors

        #region Protected Constructors
        protected Product()
        {
            _orderProducts = new List<OrderProduct>();
        }
        #endregion Protected Constructors

        #region Public Properties

        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }

        public IEnumerable<OrderProduct> OrderProducts => _orderProducts;


        #endregion Public Properties


        #region Public Methods
        public void Update(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidateName();
            ValidateDescription();
            ValidatePrice();

            AddErrors(Validate(this));

            return ValidationResult.IsValid;
        }

        #endregion Public Methods


        #region Private Methods
        private void ValidateName()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(5, 100).WithMessage("Email must contain between 5 and 100 characters");
        }

        private void ValidateDescription()
        {
            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .Length(5, 256).WithMessage("Description must contain between 5 and 256 characters");
        }

        private void ValidatePrice()
        {
            RuleFor(d => d.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be greater than zero");
        }
        #endregion Private Methods
    }
}

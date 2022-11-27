using Store.Domain._shared;

namespace Store.Domain.Entities
{
    public class Product : Entity
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
        #endregion Public Methods
    }
}

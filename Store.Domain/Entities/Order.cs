using FluentValidation;
using Store.Domain._shared;
using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Order : Entity<Order>
    {
        #region Protected Fields
        
        protected IList<OrderProduct> _orderProducts;

        #endregion Protected fields

        #region Constructors
        public Order(Guid userId, EOrderStatus status)
        {
            UserId = userId;
            Status = status;
            _orderProducts = new List<OrderProduct>();
        }
        
        protected Order()
        {
            _orderProducts = new List<OrderProduct>();
        }

        #endregion Constructors

        #region Public Properties

        public Guid UserId { get; private set; }
        public EOrderStatus Status { get; private set; }
        public User? User { get; private set; }
        public IEnumerable<OrderProduct> OrderProducts => _orderProducts;
        #endregion Public properties

        #region Public Methods
        public void AddOrderProduct(OrderProduct orderProduct)
        {
            _orderProducts.Add(orderProduct);
        }

        public void SetStatus(EOrderStatus status)
        {
            Status = status;
        }

        public override bool IsValid()
        {
            ValidateSurveyId();

            AddErrors(Validate(this));

            return ValidationResult.IsValid;
        }
        #endregion Public Methods


        #region Private Methods
        private void ValidateSurveyId()
        {
            RuleFor(i => i.UserId)
                .NotEmpty()
                .WithMessage("Id of User cannot be empty.");
        }

        #endregion Private Methods
    }
}

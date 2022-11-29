using FluentValidation;
using Store.Domain._shared;

namespace Store.Domain.Entities
{
    public class OrderProduct : Entity<OrderProduct>
    {
        public OrderProduct(Guid orderId, Guid productId, int quantity, decimal currentPrice)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            CurrentPrice = currentPrice;
        }

        protected OrderProduct()
        {

        }

        public Guid OrderId { get; private set; }
        public Order? Order { get; private set; }
        public Guid ProductId { get; private set; }
        public Product? Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal CurrentPrice { get; private set; }

        public override bool IsValid()
        {
            ValidateOrderId();
            ValidateProductId();
            ValidateQuantity();
            ValidateCurrentPrice();

            AddErrors(Validate(this));

            return ValidationResult.IsValid;
        }

        private void ValidateOrderId()
        {
            RuleFor(i => i.OrderId)
                .NotEmpty()
                .WithMessage("Id of Order cannot be empty.");
        }

        private void ValidateProductId()
        {
            RuleFor(i => i.ProductId)
                .NotEmpty()
                .WithMessage("Id of Product cannot be empty.");
        }

        private void ValidateQuantity()
        {
            RuleFor(i => i.Quantity)
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .WithMessage("Quantity must be greater than zero");
        }

        private void ValidateCurrentPrice()
        {
            RuleFor(d => d.CurrentPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Current Price must be greater than zero");
        }
    }
}

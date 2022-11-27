using Store.Domain._shared;

namespace Store.Domain.Entities
{
    public class OrderProduct : Entity
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
    }
}

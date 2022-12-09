namespace Store.Application.Dtos.Order.Response
{
    public class SearchOrderProductModelResponseDto
    {
        public SearchOrderProductModelResponseDto(Guid id, string name, decimal currentPrice, int quantity)
        {
            Id = id;
            Name = name;
            CurrentPrice = currentPrice;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
        public int Quantity { get; set; }
    }
}

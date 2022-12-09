namespace Store.Application.Dtos.Product.Response
{
    public class ProductResponseDto
    {

        public ProductResponseDto(Guid id, string name, string description, decimal price, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

namespace Store.Application.Dtos.Product.Request
{
    public class UpdateProductRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}

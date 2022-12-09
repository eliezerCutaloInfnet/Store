namespace Store.Application.Dtos.Product.Response
{
    public class CreateProductResponseDto
    {
        public CreateProductResponseDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

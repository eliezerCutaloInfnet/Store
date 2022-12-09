namespace Store.Application.Dtos.Order.Response
{
    public class CreateOrderModelResponseDto
    {
        public CreateOrderModelResponseDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

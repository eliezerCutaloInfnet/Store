using Store.Domain.Enums;

namespace Store.Application.Dtos.Order.Response
{
    public class SearchOrderModelResponseDto
    {
        public SearchOrderModelResponseDto(Guid id, Guid userId, string userName, EOrderStatus status)
        {
            Id = id;
            UserId = userId;
            UserName = userName;
            Status = status;
            Products = new List<SearchOrderProductModelResponseDto>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public EOrderStatus Status { get; set; }

        public List<SearchOrderProductModelResponseDto> Products { get; set; }
    }
}

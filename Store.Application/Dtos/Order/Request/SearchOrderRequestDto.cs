namespace Store.Application.Dtos.Order.Request
{
    public class SearchOrderRequestDto
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Store.Application.Dtos.Product.Request
{
    public class SearchProductRequestDto
    {
        [Required]
        public string? Name { get; set; }
    }
}

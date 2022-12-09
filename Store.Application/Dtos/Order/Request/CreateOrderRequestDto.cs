using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Dtos.Order.Request
{
    public class CreateOrderRequestDto
    {
        public CreateOrderRequestDto()
        {
            Products = new List<CreateOrderProductRequestDto>();
        }

        public Guid? UserId { get; set; }
        public List<CreateOrderProductRequestDto> Products { get; set; }

    }
}

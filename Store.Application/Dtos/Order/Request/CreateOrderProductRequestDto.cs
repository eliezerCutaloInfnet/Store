using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Dtos.Order.Request
{
    public class CreateOrderProductRequestDto
    {
        public Guid Id { get; set; }
        public decimal CurrentPrice { get; set; } 
        public int Quantity { get; set; }
    }
}

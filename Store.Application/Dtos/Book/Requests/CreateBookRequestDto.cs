using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Dtos.Book.Requests
{
    public class CreateBookRequestDto
    {
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
    }
}

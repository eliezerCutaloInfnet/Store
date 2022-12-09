using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Dtos.Product.Response
{
    public class UpdateProductResponseDto
    {
        #region Public Constructors

        public UpdateProductResponseDto(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        #endregion Public Constructors

        #region Public Properties

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        #endregion Public Properties
    }
}

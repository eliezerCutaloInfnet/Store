using Store.Application._shared;
using Store.Application.Dtos.Order.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task<IAppServiceResponse> Create(CreateOrderRequestDto request);

        Task<IAppServiceResponse> GetAll(SearchOrderRequestDto request);
    }
}

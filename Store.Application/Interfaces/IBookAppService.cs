using Store.Application._shared;
using Store.Application.Dtos.Book.Requests;
using Store.Application.Dtos.Product.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IBookAppService
    {
        Task<IAppServiceResponse> GetAllAsync();
        Task<IAppServiceResponse> GetByIsbnAsync(string isbn);
        Task<IAppServiceResponse> Delete(string isbn);
        Task<IAppServiceResponse> Create(CreateBookRequestDto request);
        Task<IAppServiceResponse> Update(UpdateBookRequestDto request, string isbn);
    }
}

using Store.Application._shared;
using Store.Application.Dtos.Product.Request;

namespace Store.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IAppServiceResponse> SearchByName(SearchProductRequestDto request);
        Task<IAppServiceResponse> GetById(Guid Id);
        Task<IAppServiceResponse> Create(CreateProductRequestDto request);
        Task<IAppServiceResponse> Update(UpdateProductRequestDto request, Guid id);
    }
}

using Store.Application._shared;
using Store.Application.Dtos.User.Request;

namespace Store.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<IAppServiceResponse> GetAll(SearchUserRequestDto request);
    }
}

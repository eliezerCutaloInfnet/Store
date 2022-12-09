using Store.Application._shared;
using Store.Application.Dtos.Login.Request;

namespace Store.Application.Interfaces
{
    public interface ILoginAppService
    {
        Task<IAppServiceResponse> SignUp(SignUpRequestDto request);
    }
}

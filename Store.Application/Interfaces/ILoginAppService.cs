using Store.Application._shared;
using Store.Application.Dtos.Login;

namespace Store.Application.Interfaces
{
    public interface ILoginAppService
    {
        Task<AppServiceResponse> SignUp(SignUpRequestDto request);
    }
}

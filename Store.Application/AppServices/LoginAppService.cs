using Store.Application._shared;
using Store.Application.Dtos.Login;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Interface;

namespace Store.Application.AppServices
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUserRepository _userRepository;

        public LoginAppService(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public async Task<AppServiceResponse> SignUp(SignUpRequestDto request)
        {
            var existentUser = await _userRepository.GetByUsernameAsync(request.UserName);

            if (existentUser is not null)
                return new AppServiceResponse(false, "User already exists");

            var newUser = new User(request.Name, request.UserName, request.Password, request.Email);

            if (!newUser.IsValid())
                return new AppServiceResponse(false, "Error to create user");

            await _userRepository.AddAsync(newUser);

            return new AppServiceResponse(true, "User was created");

        }
    }
}

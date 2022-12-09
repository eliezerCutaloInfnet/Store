using Store.Application._shared;
using Store.Application.Dtos.Login.Request;
using Store.Application.Dtos.Login.Response;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Interface;

namespace Store.Application.AppServices
{
    public class LoginAppService : AppService, ILoginAppService
    {
        private readonly IUserRepository _userRepository;

        public LoginAppService(INotifier notifier, IUserRepository repository) : base(notifier)
        {
            _userRepository = repository;
        }
        public async Task<IAppServiceResponse> SignUp(SignUpRequestDto request)
        {
            var existentUser = await _userRepository.GetByUsernameAsync(request.UserName);
             
            if (existentUser != null)
            {
                Notify("Username", "User already exists");
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Creating User", false);
            }
                

            var newUser = new User(request.Name, request.UserName, request.Password, request.Email);

            if (!newUser.IsValid())
            {
                Notify(newUser.ValidationResult);

                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Creating User", false);
            }
                

            await _userRepository.AddAsync(newUser);

            return new AppServiceResponse<SignUpResponseDto>(new SignUpResponseDto(newUser.Id, newUser.Username), "User Created Successfully", true);

        }
    }
}

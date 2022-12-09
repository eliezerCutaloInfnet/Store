using AutoFixture;
using Moq;
using Store.Application._shared;
using Store.Application.AppServices;
using Store.Application.Dtos.Login.Request;
using Store.Domain.Interface;
using Store.Tests.Common.Builders.Entities;

namespace Store.ApplicationTests.AppServices
{
    public class LoginAppServiceTest
    {
        private LoginAppService _loginAppService;
        private Fixture _fixture;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<INotifier> _notifierMock;

        public LoginAppServiceTest()
        {
            _fixture = new Fixture();
            _userRepositoryMock = new Mock<IUserRepository>();
            _notifierMock = new Mock<INotifier>();
        }
        
        [Fact]
        public async Task ShouldCreateUser()
        {
            var signUpRequestDto = _fixture.Create<SignUpRequestDto>();
            _loginAppService = new LoginAppService(_notifierMock.Object, _userRepositoryMock.Object);

            var response = await _loginAppService.SignUp(signUpRequestDto);

            Assert.True(response.Success);

        }

        [Fact]
        public async Task ShouldntCreateSameUser()
        {
            
            var signUpRequestDto = _fixture.Create<SignUpRequestDto>();
            var user = UserBuilder.New().WithUserName(signUpRequestDto.UserName).Build();

            _userRepositoryMock.Setup(
                x => x.GetByUsernameAsync(signUpRequestDto.UserName)).Returns(Task.FromResult(user));

            _loginAppService = new LoginAppService(_notifierMock.Object, _userRepositoryMock.Object);

            var response = await _loginAppService.SignUp(signUpRequestDto);

            Assert.False(response.Success);

        }

    }
}

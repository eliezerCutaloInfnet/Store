using Store.Tests.Common.Builders.Entities;

namespace Store.DomainTests.Entities
{
    public class UserTest
    {
        [Fact(DisplayName = "Create User")]
        public void CreateUser()
        {
           var user = UserBuilder.New().Build();
            Assert.True(user.IsValid());
        }

        [Theory(DisplayName = "Shouldn't create with invalid username")]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("iUHJmmOdhXdTrzFtwLlKSuFQMyZsjIZTWnssePLynbPsHaYertITkFfmKcRXHYiwQNmbMpOkmTWcOesRN\r\nVdxyoiehEpOGBxnzgOfy\r\niTKBOpMMLRjaLPbWsvfy\r\nVKZDeauAZIdwgCZPAXjQBNLZPsCfjrSukZOwHQgLjEsdHmtWmAmALDQHtbrJHThYgIDWgAZNPRQvGyyd")]
        public void ShouldntCreateUserWithInvalidUserName(string userName)
        {
            var user = UserBuilder.New().WithUserName(userName).Build();
            Assert.False(user.IsValid());
        }

        [Theory(DisplayName = "Shouldn't create with invalid name")]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("iUHJmmOdhXdTrzFtwLlKSuFQMyZsjIZTWnssePLynbPsHaYertITkFfmKcRXHYiwQNmbMpOkmTWcOesRN\r\nVdxyoiehEpOGBxnzgOfy\r\niTKBOpMMLRjaLPbWsvfy\r\nVKZDeauAZIdwgCZPAXjQBNLZPsCfjrSukZOwHQgLjEsdHmtWmAmALDQHtbrJHThYgIDWgAZNPRQvGyyd")]
        public void ShouldntCreateUserWithInvalidName(string name)
        {
            var user = UserBuilder.New().WithName(name).Build();
            Assert.False(user.IsValid());
        }

        [Theory(DisplayName = "Shouldn't create with invalid password")]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("iUHJmmOdhXdTrzFtwLlKSuFQMyZsjIZTWnssePLynbPsHaYertITkFfmKcRXHYiwQNmbMpOkmTWcOesRN\r\nVdxyoiehEpOGBxnzgOfy\r\niTKBOpMMLRjaLPbWsvfyVKZDeauAZIdwgCZPAXjQBNLZPsCfjrSukZOwHQgLjEsdHmtWmAmALDQHtbrJHThYgIDWgAZNPRQvGyyd")]
        public void ShouldntCreateUserInvalidPassword(string password)
        {
            var user = UserBuilder.New().WithPassword(password).Build();
            Assert.False(user.IsValid());
        }
    }
}

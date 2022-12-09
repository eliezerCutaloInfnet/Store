namespace Store.Application.Dtos.User.Response
{
    public class SearchUserResponseDto
    {
        #region Public Constructors

        public SearchUserResponseDto(Guid id, string name, string username, string email, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            CreatedAt = createdAt;
        }

        #endregion Public Constructors

        #region Public Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Public Properties
    }
}

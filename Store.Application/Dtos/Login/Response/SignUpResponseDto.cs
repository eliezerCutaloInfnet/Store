namespace Store.Application.Dtos.Login.Response
{
    public class SignUpResponseDto
    {
        public SignUpResponseDto(Guid? id, string? username)
        {
            Id = id;
            Username = username;
        }

        public Guid? Id { get; set; }

        public string? Username { get; set; }
    }
}

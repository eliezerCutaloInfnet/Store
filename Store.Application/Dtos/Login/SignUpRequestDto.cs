namespace Store.Application.Dtos.Login
{
    public class SignUpRequestDto
    {
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}

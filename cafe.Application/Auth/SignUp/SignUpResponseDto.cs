namespace cafe.Application.Auth.SignUp;

public class SignUpResponseDto
{
    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }
}

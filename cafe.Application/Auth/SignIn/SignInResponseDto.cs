namespace cafe.Application.Auth.SignIn;

public class SignInResponseDto
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public int ExpiresIn { get; set; }
}

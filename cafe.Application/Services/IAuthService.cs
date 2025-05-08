namespace cafe.Application.Services;

public interface IAuthService
{
    string GetToken(string username);
}

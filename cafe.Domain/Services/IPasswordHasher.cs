namespace cafe.Domain.Services;

public interface IPasswordHasher
{
    string HashPassword(string password);

    bool VerifyHash(string password, string hash);
}

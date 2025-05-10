using System.Security.Cryptography;
using System.Text;

namespace cafe.Domain.Helper;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA512;

    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool VerifyHash(string password, string hash)
    {
        var parts = hash.Split('-'); 
        if (parts.Length != 2)
            throw new FormatException("Invalid hash format.");

        var hashBytes = Convert.FromHexString(parts[0]);
        var saltBytes = Convert.FromHexString(parts[1]);

        var hashToVerify = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, Iterations, HashAlgorithmName, HashSize);

        return CryptographicOperations.FixedTimeEquals(hashBytes, hashToVerify);
    }
}

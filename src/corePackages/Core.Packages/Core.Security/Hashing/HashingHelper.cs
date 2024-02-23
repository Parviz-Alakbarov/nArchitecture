using System.Security.Cryptography;
using System.Text;

namespace Core.Security.Hashing;

public static class HashingHelper
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using HMACSHA512 hmac = new();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
    {
        using HMACSHA512 hmac = new(passwordSalt);
        byte[] computedHash = hmac.ComputeHash(passwordSalt);
        return computedHash.SequenceEqual(passwordHash);
    }
}

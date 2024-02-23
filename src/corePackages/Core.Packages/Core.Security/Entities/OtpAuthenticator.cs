using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OtpAuthenticator : Entity<int>
{
    public int UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; } = null;

    public OtpAuthenticator()
    {
        SecretKey = Array.Empty<byte>();
    }

    public OtpAuthenticator(int userId, byte[] secretKey, bool ısVerified)
    {
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = ısVerified;
    }

    public OtpAuthenticator(int id, int userId, byte[] secretKey, bool ısVerified):base(id)
    {
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = ısVerified;
    }
}

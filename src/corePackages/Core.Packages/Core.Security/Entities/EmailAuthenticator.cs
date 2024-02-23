using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class EmailAuthenticator : Entity<int>
{
    public int UserId { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }
    public virtual User User { get; set; } = null;

    public EmailAuthenticator() { }

    public EmailAuthenticator(int userId, bool ısVerified)
    {
        UserId = userId;
        IsVerified = ısVerified;
    }

    public EmailAuthenticator(int id, int userId, bool ısVerified) : base(id)
    {
        UserId = userId;
        IsVerified = ısVerified;
    }
}

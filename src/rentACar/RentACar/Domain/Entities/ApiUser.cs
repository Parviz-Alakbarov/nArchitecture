
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApiUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; } = string.Empty;
}

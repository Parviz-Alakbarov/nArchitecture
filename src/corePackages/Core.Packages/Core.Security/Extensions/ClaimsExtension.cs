using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Security.Extensions;

public static class ClaimsExtension
{
    public static void AddEmail(this ICollection<Claim> claims, string email) => claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));

    public static void AddName(this ICollection<Claim> claims, string name) => claims.Add(new Claim(JwtRegisteredClaimNames.Name, name));

    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier) => claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));

    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
    }
}

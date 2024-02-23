using System.Security.Claims;

namespace Core.Security.Extensions;

public static class ClaimPrincipalsExtension
{
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType) { return claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); }

    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal) => claimsPrincipal?.Claims(ClaimTypes.Role);

    public static int GetUserId(this ClaimsPrincipal claimsPrincipal) => Convert.ToInt32(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
}

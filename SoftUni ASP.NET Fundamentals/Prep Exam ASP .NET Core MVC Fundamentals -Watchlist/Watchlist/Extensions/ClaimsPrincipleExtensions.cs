using System.Security.Claims;

namespace Watchlist.Extensions
{
    public static class ClaimsPrincipleExtensions 
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

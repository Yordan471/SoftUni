using Microsoft.AspNetCore.Identity;
using System.Composition.Convention;
using System.Security.Claims;

namespace Homies.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUserById(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

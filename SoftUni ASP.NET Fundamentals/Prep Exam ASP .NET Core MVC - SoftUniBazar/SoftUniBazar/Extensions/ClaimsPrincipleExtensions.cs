using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace SoftUniBazar.Extensions
{
    public class ClaimsPrincipleExtensions
    {
        public static string GetId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

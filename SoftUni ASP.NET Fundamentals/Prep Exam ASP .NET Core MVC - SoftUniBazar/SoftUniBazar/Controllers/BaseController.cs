using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}

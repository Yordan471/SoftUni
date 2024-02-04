using Homies.Data.Models;
using Homies.Extensions;
using Homies.Services.Contracts;
using Homies.ViewModels.EventViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using static Homies.Extensions.ClaimsPrincipleExtensions;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<EventViewModel> allEvents = await eventService.GetAllEventsAsync();

            return View(allEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Joined(int id)
        {
            Event dbEvent = await eventService.GetEventByIdAsync(id);

            if (dbEvent == null)
            {

                return BadRequest();
            }

             string userId = ClaimsPrincipleExtensions.GetUserById(this.User);

            
        }
    }
}

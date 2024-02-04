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

        [HttpGet]
        public async Task<IActionResult> Joined(int id)
        {
            Event dbEvent = await eventService.GetEventByIdAsync(id);

            if (dbEvent == null)
            {
                return BadRequest();
            }

            string userId = ClaimsPrincipleExtensions.GetUserById(this.User);

            await eventService.AddEventParticipantToDbAsync(dbEvent, userId);

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            string userId = ClaimsPrincipleExtensions.GetUserById(this.User);

            EventParticipant eventParticipant = await eventService.GetEventParticipantAsync(id, userId);

            if (eventParticipant == null)
            {
                return BadRequest();
            }

            await eventService.RemoveEventParticipantAsync(eventParticipant);

            return RedirectToAction(nameof(All));
        }
    }
}

using Homies.Services.Contracts;
using Homies.ViewModels.EventViewModels;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<AllEventViewModel> allEvents = await eventService.GetAllEvents();

            return View(allEvents);
        }
    }
}

using Homies.Data.Models;
using Homies.Extensions;
using Homies.Services.Contracts;
using Homies.ViewModels.EventViewModels;
using Homies.ViewModels.TypeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using static Homies.Extensions.ClaimsPrincipleExtensions;
using static Homies.Common.ModelStateErrorMessages.AddModelStateErrorMessages;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;
        private readonly ITypeService typeService;

        public EventController(IEventService eventService, ITypeService typeService)
        {
            this.eventService = eventService;
            this.typeService = typeService;
        }

        [HttpGet]
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

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            IEnumerable<TypeViewModel> types = await typeService.GetAllTypesAsync();

            AddEventViewModel addEventViewModel = new()
            {
                Types = types
            };

            return View(addEventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel addEventViewModel)
        {
            IEnumerable<TypeViewModel> types = await typeService.GetAllTypesAsync();

            if (!types.Any(t => t.Id == addEventViewModel.TypeId))
            {
                ModelState.AddModelError("typeId", AddTypeIdDoesNotExist);
            }

            if (!ModelState.IsValid)
            {
                addEventViewModel.Types = types;
                return View(addEventViewModel);
            }

            string userId = ClaimsPrincipleExtensions.GetUserById(this.User);

            await eventService.MapAddEventViewModelToEventAsync(addEventViewModel, userId);

            return RedirectToAction(nameof(All));
        }
    }
}

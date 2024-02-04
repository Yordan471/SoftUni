using Homies.Data.Models;
using Homies.Extensions;
using Homies.Services.Contracts;
using Homies.ViewModels.EventViewModels;
using Homies.ViewModels.TypeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using static Homies.Extensions.ClaimsPrincipleExtensions;
using static Homies.Common.ModelStateErrorMessages.AddModelStateErrorMessages;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

        public async Task<IActionResult> Join(int id)
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
        public async Task<IActionResult> Joined()
        {
            string userId = ClaimsPrincipleExtensions.GetUserById(this.User);

            IEnumerable<EventJoinedViewModel> myJoinedEventViewModels =
                await eventService.GetAllMyJointEventsAsync(userId);

            return View(myJoinedEventViewModels);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Event eventToEdit = await eventService.GetEventByIdAsync(id);

            if (eventToEdit == null)
            {
                return BadRequest();
            }

            string currentUserId = ClaimsPrincipleExtensions.GetUserById(this.User);
            if (currentUserId != eventToEdit.OrganiserId)
            {
                return Unauthorized();
            }

            AddEventViewModel eventViewModel = eventService.MapEventToEventViewModel(eventToEdit);
            eventViewModel.Types = await typeService.GetAllTypesAsync();

            return View(eventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddEventViewModel editEventViewModel)
        {
            Event eventToEdit = await eventService.GetEventByIdAsync(id);

            if (eventToEdit == null)
            {
                return BadRequest();
            }

            string currentUser = ClaimsPrincipleExtensions.GetUserById(this.User);
            if (currentUser != eventToEdit.OrganiserId)
            {
                return Unauthorized();
            }

            IEnumerable<TypeViewModel> types = await typeService.GetAllTypesAsync();

            if (!types.Any(e => e.Id == editEventViewModel.TypeId))
            {
                ModelState.AddModelError(nameof(editEventViewModel.TypeId), AddTypeIdDoesNotExist);
            }

            await eventService.MapEditEventViewModelToEventSaveChangesAsync(editEventViewModel, eventToEdit);

            return RedirectToAction(nameof(All));   
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Event getEvent = await eventService.GetEventByIdAsync(id);

            if (getEvent == null)
            {
                return BadRequest();
            }

            IEnumerable<TypeViewModel> types = await typeService.GetAllTypesAsync();

            EventDetailsViewModel eventDetailsViewModel = await
                eventService.MapEventToEventDetailsViewModel(getEvent, types);

            return View(eventDetailsViewModel);
        }
    }
}

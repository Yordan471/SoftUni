using Homies.Data.Models;
using Homies.ViewModels.EventViewModels;
using Homies.ViewModels.TypeViewModels;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        public Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

        public Task<Event> GetEventByIdAsync(int id);

        public Task AddEventParticipantToDbAsync(Event dbEvent, string userId);

        public Task<EventParticipant> GetEventParticipantAsync(int id, string userId);

        public Task RemoveEventParticipantAsync(EventParticipant eventParticipant);

        public Task MapAddEventViewModelToEventAsync(AddEventViewModel addEventViewModel, string userId);

        public AddEventViewModel MapEventToEventViewModel(Event eventToEdit);

        public Task MapEditEventViewModelToEventSaveChangesAsync(AddEventViewModel ediViewModel, Event eventToEdit);

        public Task<EventDetailsViewModel> MapEventToEventDetailsViewModel(Event eventDetails, IEnumerable<TypeViewModel> types);

        public Task<IEnumerable<EventJoinedViewModel>> GetAllMyJointEventsAsync(string userId);
    }
}

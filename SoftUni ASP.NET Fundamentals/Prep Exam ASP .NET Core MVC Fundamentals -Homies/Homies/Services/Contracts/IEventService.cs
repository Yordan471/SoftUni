using Homies.Data.Models;
using Homies.ViewModels.EventViewModels;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        public Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

        public Task<Event> GetEventByIdAsync(int id);

        public Task AddEventParticipantToDbAsync(Event dbEvent, string userId);

        public Task<EventParticipant> GetEventParticipantAsync(int id, string userId);

        public Task RemoveEventParticipantAsync(EventParticipant eventParticipant);
    }
}

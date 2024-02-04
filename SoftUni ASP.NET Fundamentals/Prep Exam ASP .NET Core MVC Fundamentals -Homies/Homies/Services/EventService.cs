using Homies.Data;
using Homies.Data.Models;
using Homies.Services.Contracts;
using Homies.ViewModels.EventViewModels;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;
        public EventService(HomiesDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task AddEventParticipantToDbAsync(Event eventDb, string userId)
        {
            EventParticipant eventParticipant = new()
            {
                Event = eventDb,
                HelperId = userId
            };

            if (!await dbContext.EventsParticipants.ContainsAsync(eventParticipant))
            {
                await dbContext.EventsParticipants.AddAsync(eventParticipant);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventViewModel>> GetAllEventsAsync()
        {
            string startDateTimeFormat = "yyyy-MM-dd H:mm";

            return dbContext.Events.Select(e => new EventViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Organiser = e.Organiser.UserName,
                Start = e.Start.ToString(startDateTimeFormat),
                Type = e.Type.Name
            }).AsNoTracking()
            .AsEnumerable();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await dbContext.Events.FirstAsync(e => e.Id == id);
        }

        public async Task<EventParticipant> GetEventParticipantAsync(int id, string userId)
        {
            return await dbContext.EventsParticipants
                .FirstAsync(ep => ep.EventId == id && ep.HelperId == userId);
        }

        public async Task RemoveEventParticipantAsync(EventParticipant eventParticipant)
        {
            dbContext.EventsParticipants.Remove(eventParticipant);
            await dbContext.SaveChangesAsync();
        }
    }
}

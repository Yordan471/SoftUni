﻿using Homies.Data;
using Homies.Data.Models;
using Homies.Services.Contracts;
using Homies.ViewModels.EventViewModels;
using Homies.ViewModels.TypeViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Event = Homies.Data.Models.Event;

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
                EventId = eventDb.Id,
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

            return await dbContext.Events.Select(e => new EventViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Organiser = e.Organiser.UserName,
                Start = e.Start.ToString(startDateTimeFormat),
                Type = e.Type.Name
            }).AsNoTracking()
            .ToListAsync();
        }

        public async Task<IEnumerable<EventJoinedViewModel>> GetAllMyJointEventsAsync(string userId)
        {
            string startDateTimeFormat = "yyyy-MM-dd H:mm";

            return await dbContext.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new EventJoinedViewModel
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(startDateTimeFormat),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName
                }).AsNoTracking()
                .ToArrayAsync();
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

        public async Task MapAddEventViewModelToEventAsync(AddEventViewModel addEventViewModel, string userId)
        {
            Event addEvent = new()
            {
                Name = addEventViewModel.Name,
                Description = addEventViewModel.Description,
                OrganiserId = userId,
                CreatedOn = DateTime.UtcNow,
                Start = addEventViewModel.Start,
                End = addEventViewModel.End,
                TypeId = addEventViewModel.TypeId,
            };
            
            await dbContext.Events.AddAsync(addEvent);
            await dbContext.SaveChangesAsync();
        }

        public async Task MapEditEventViewModelToEventSaveChangesAsync(AddEventViewModel editEventViewModel, Event eventToEdit)
        {
            eventToEdit.Name = editEventViewModel.Name;
            eventToEdit.Description = editEventViewModel.Description;
            eventToEdit.Start = editEventViewModel.Start;
            eventToEdit.End = editEventViewModel.End;
            eventToEdit.TypeId = editEventViewModel.TypeId;

            await dbContext.SaveChangesAsync();
        }

        public async Task<EventDetailsViewModel> MapEventToEventDetailsViewModel(Event eventDetails, IEnumerable<TypeViewModel> types)
        {
            string startDateTimeFormat = "yyyy-MM-dd H:mm";

            IdentityUser organiser = await dbContext.Users.FirstAsync(u => u.Id == eventDetails.OrganiserId);

            string type = types.FirstOrDefault(t => t.Id == eventDetails.TypeId).Name;

            EventDetailsViewModel eventDetailsViewModel = new()
            {
                Id = eventDetails.Id,
                Name = eventDetails.Name,
                Description = eventDetails.Description,
                Start = eventDetails.Start.ToString(startDateTimeFormat),
                End = eventDetails.End.ToString(startDateTimeFormat),
                CreatedOn = eventDetails.CreatedOn.ToString(startDateTimeFormat),
                Organiser = organiser.UserName,
                Type = type
            };

            return eventDetailsViewModel;
        }

        public AddEventViewModel MapEventToEventViewModel(Event eventToEdit)
        {
            string startDateTimeFormat = "yyyy-MM-dd H:mm";

            AddEventViewModel eventViewModel = new()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start,
                End = eventToEdit.End,
                TypeId = eventToEdit.TypeId,
            };

            return eventViewModel;
        }

        public async Task RemoveEventParticipantAsync(EventParticipant eventParticipant)
        {
            dbContext.EventsParticipants.Remove(eventParticipant);
            await dbContext.SaveChangesAsync();
        }
    }
}

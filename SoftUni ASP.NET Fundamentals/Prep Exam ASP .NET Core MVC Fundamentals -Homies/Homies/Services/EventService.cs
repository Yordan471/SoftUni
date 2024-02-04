using Homies.Data;
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

        public async Task<IEnumerable<AllEventViewModel>> GetAllEvents()
        {
            string startDateTimeFormat = "yyyy-MM-dd H:mm";

            return dbContext.Events.Select(e => new AllEventViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Organiser = e.Organiser.UserName,
                Start = e.Start.ToString(startDateTimeFormat),
                Type = e.Type.Name
            }).AsNoTracking()
            .AsEnumerable();
        }
    }
}

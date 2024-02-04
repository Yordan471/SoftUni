using Homies.ViewModels.EventViewModels;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        public Task<IEnumerable<AllEventViewModel>> GetAllEvents();
    }
}

using CommunityEventPlanner.Client.Models;
using CommunityEventPlanner.Client.Models.Events;

namespace CommunityEventPlanner.Client.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetUpcomingEventsAsync();
        Task<ApiResponse<Event>> CreateEventAsync(CreateEventRequest request);
    }
}

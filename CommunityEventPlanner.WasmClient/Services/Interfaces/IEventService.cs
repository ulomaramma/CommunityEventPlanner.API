using CommunityEventPlanner.Client.Models;
using CommunityEventPlanner.Client.Models.Events;

namespace CommunityEventPlanner.Client.Services.Interfaces
{
    public interface IEventService
    {
        Task<ApiResponse> GetUpcomingEventsAsync();
        Task<ApiResponse> CreateEventAsync(CreateEventRequest request);
    }
}

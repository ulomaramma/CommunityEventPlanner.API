
using System.Net.Http.Json;
using CommunityEventPlanner.Client.Models;
using CommunityEventPlanner.Client.Models.Events;
using CommunityEventPlanner.Client.Services.Interfaces;

namespace CommunityEventPlanner.Client.Services
{
    public class EventService :IEventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> GetUpcomingEventsAsync()
        {
            var response = await _httpClient.GetAsync("api/events/upcoming");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse>();
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return new ApiResponse(false, (int)response.StatusCode, message: errorResponse?.Message);

            }
        }

        public async Task<ApiResponse> CreateEventAsync(CreateEventRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/events", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse>();
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return new ApiResponse(false, (int)response.StatusCode, message: errorResponse?.Message);
            }
        }
    }
}

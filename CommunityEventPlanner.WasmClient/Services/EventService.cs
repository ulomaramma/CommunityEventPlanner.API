
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using CommunityEventPlanner.Client.Models;
using CommunityEventPlanner.Client.Models.Events;
using CommunityEventPlanner.Client.Services.Interfaces;
using CommunityEventPlanner.Client.Utils;
using static System.Net.WebRequestMethods;

namespace CommunityEventPlanner.Client.Services
{
    public class EventService :IEventService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public EventService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<List<Event>> GetUpcomingEventsAsync()
        {           
                var response = await _httpClient.GetAsync("api/events/upcoming");
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<Event>>>();
                    if (apiResponse != null && apiResponse.Success)
                    {
                        return apiResponse.Data;
                    }
                }                         
            return new List<Event>();
        }
        

        public async Task<ApiResponse<Event>> CreateEventAsync(CreateEventRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/events", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse<Event>>();
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiResponse<Event>>();
                return new ApiResponse<Event>(false, (int)response.StatusCode, errorResponse?.Data, errorResponse?.Message);
            }
        }
    }
}

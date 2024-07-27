using CommunityEventPlanner.Client.Services.Interfaces;
using System.Net.Http.Json;

namespace CommunityEventPlanner.Client.Services
{
    public class BaseService : IBaseService
    {
        protected readonly HttpClient _httpClient;

        protected BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<T>();
            if (result == null)
            {
                throw new NullReferenceException($"Response content for GET '{uri}' is null.");
            }
            return result;
        }

        public async Task<T> PostAsync<T>(string uri, object value)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<T>();
            if (result == null)
            {
                throw new NullReferenceException($"Response content for POST '{uri}' is null.");
            }
            return result;
        }

        public async Task<T> PutAsync<T>(string uri, object value)
        {
            var response = await _httpClient.PutAsJsonAsync(uri, value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<T>();
            if (result == null)
            {
                throw new NullReferenceException($"Response content for PUT '{uri}' is null.");
            }
            return result;
        }

        public async Task DeleteAsync(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
        }
    }
}

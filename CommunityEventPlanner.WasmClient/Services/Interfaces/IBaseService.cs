namespace CommunityEventPlanner.Client.Services.Interfaces
{
    public interface IBaseService
    {
        Task<T> GetAsync<T>(string uri);
        Task<T> PostAsync<T>(string uri, object value);
        Task<T> PutAsync<T>(string uri, object value);
        Task DeleteAsync(string uri);
    }
}

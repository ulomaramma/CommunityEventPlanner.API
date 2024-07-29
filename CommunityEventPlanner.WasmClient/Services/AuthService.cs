using CommunityEventPlanner.Client.Models;
using CommunityEventPlanner.Client.Models.Auth;
using CommunityEventPlanner.Client.Services.Interfaces;
using CommunityEventPlanner.Client.Utils;
using System.Net.Http.Headers;

namespace CommunityEventPlanner.Client.Services
{
    public class AuthService:BaseService, IAuthService
    {
        private readonly CustomAuthStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(HttpClient httpClient, CustomAuthStateProvider authStateProvider, ILocalStorageService localStorageService)
            : base(httpClient)
        {
            _authStateProvider = authStateProvider;
            _localStorageService = localStorageService;
        }

        public async Task<AuthResponse> SignUpAsync(SignUpRequest signUpRequest)
        {
            var response =  await PostAsync<AuthResponse>("api/auth/sign-up", signUpRequest);
            if (response?.Success == true)
            {
                _authStateProvider.MarkUserAsAuthenticated(response.JwtToken);
            }
            return response;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest loginRequest)
        {
            var response = await PostAsync<AuthResponse>("api/auth/login", loginRequest);
            if (response?.Success == true)
            {
                _authStateProvider.MarkUserAsAuthenticated(response.JwtToken);
            }
            return response;
        }
        public async Task LogoutAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            await _localStorageService.RemoveItemAsync(Constants.TokenKey);
            await _authStateProvider.MarkUserAsLoggedOut();
        }
    }
}

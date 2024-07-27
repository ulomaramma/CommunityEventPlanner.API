using CommunityEventPlanner.Client.Models;
using CommunityEventPlanner.Client.Models.Auth;
using CommunityEventPlanner.Client.Models.Dtos;
using CommunityEventPlanner.Client.Services.Interfaces;

namespace CommunityEventPlanner.Client.Services
{
    public class AuthService:BaseService, IAuthService
    {
        public AuthService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ApiResponse<UserDto>> SignUpAsync(SignUpRequest signUpRequest)
        {
            return await PostAsync<ApiResponse<UserDto>>("api/auth/sign-up", signUpRequest);
        }

        public async Task<ApiResponse<UserDto>> LoginAsync(LoginRequest loginRequest)
        {
            return await PostAsync<ApiResponse<UserDto>>("api/auth/login", loginRequest);
        }
    }
}

using CommunityEventPlanner.Client.Models;
using CommunityEventPlanner.Client.Models.Auth;
using CommunityEventPlanner.Client.Models.Dtos;

namespace CommunityEventPlanner.Client.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<UserDto>> LoginAsync(LoginRequest loginRequest);
        Task<ApiResponse<UserDto>> SignUpAsync(SignUpRequest signUpRequest);
    }
}

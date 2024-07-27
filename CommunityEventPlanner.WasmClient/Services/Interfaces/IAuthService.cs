using CommunityEventPlanner.Client.Models;
using CommunityEventPlanner.Client.Models.Auth;

namespace CommunityEventPlanner.Client.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest loginRequest);
        Task<AuthResponse> SignUpAsync(SignUpRequest signUpRequest);
    }
}

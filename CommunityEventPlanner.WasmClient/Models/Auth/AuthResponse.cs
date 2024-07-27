namespace CommunityEventPlanner.Client.Models.Auth
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string  JwtToken { get; set; }
        public string Message { get; set; }

        public AuthResponse(bool success, int code, string jwtToken, string message = null)
        {
            Success = success;
            Code = code;
            JwtToken = jwtToken;
            Message = message;
        }
    }
}

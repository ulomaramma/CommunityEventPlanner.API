namespace CommunityEventPlanner.Client.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }

        public ApiResponse(bool success, int code, object? data = null, string? message = null)
        {
            Success = success;
            Code = code;
            Data = data;
            Message = message;
        }
    }
}

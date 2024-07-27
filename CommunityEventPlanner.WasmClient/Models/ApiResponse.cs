namespace CommunityEventPlanner.Client.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public ApiResponse(bool success, int code, T data = default, string errorMessage = null)
        {
            Success = success;
            Code = code;
            Data = data;
            ErrorMessage = errorMessage;
        }
    }
}

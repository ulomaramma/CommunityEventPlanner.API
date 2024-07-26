

namespace CommunityEventPlanner.Application.UseCases.Common.Models
{
    public class ApiResponse<T>
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool success, int code, T data = default, string errorMessage = null)
        {
            Success = success;
            Code = code;
            Data = data;
            ErrorMessage = errorMessage;
        }
    }
}

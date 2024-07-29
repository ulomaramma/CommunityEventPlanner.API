

namespace CommunityEventPlanner.Application.UseCases.Common.Models
{
  
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool success, int code, T data = default, string message = null)
        {
            Success = success;
            Code = code;
            Data = data;
            Message = message;
        }
    }

}

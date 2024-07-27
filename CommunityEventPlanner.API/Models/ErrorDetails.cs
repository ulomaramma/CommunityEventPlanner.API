

namespace CommunityEventPlanner.API.Models
{
    public class ErrorDetails
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public string ErrorDetail { get; set; }
        public ErrorDetails(int statusCode, string errorMessage, string errorDetail = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            ErrorDetail = errorDetail;
        }
    }
}

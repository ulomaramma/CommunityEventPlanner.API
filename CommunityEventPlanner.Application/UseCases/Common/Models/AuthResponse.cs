using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Common.Models
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string JwtToken { get; set; }
        public string Message { get; set; }

        public AuthResponse(bool success, int code, string jwtToken = null, string message = null)
        {
            Success = success;
            Code = code;
            JwtToken = jwtToken;
            Message = message;
        }
    }
}

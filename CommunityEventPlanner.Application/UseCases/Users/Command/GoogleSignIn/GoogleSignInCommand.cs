using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Users.Command.GoogleSignIn
{
    public class GoogleSignInCommand : IRequest<ApiResponse<UserDto>>
    {
        public string IdToken { get; set; }
    }
}

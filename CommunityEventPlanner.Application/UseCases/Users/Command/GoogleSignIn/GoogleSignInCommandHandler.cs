using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.Services;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using CommunityEventPlanner.Domain.Entities;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Users.Command.GoogleSignIn
{
    public class GoogleSignInCommandHandler : IRequestHandler<GoogleSignInCommand, AuthResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public GoogleSignInCommandHandler(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<AuthResponse> Handle(GoogleSignInCommand request, CancellationToken cancellationToken)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken);
            if (payload == null)
            {
                return new AuthResponse(false, StatusCodes.Status400BadRequest, message: "Invalid Google token.");
            }

            var user = await _userManager.FindByEmailAsync(payload.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = payload.Email,
                    Email = payload.Email,
                    FirstName = payload.GivenName,
                    LastName = payload.FamilyName
                };

                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return new AuthResponse(false, StatusCodes.Status400BadRequest, message: errors);
                }
            }

            var token = await _authService.GenerateJwtToken(user);
            return new AuthResponse(true, StatusCodes.Status200OK, jwtToken:token);
        }
    }
}

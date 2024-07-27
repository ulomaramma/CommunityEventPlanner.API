using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.Services;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using CommunityEventPlanner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Users.Command.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var token = await _authService.GenerateJwtToken(user);

                return new AuthResponse(true, StatusCodes.Status201Created, jwtToken:token, message: "User Registered Sucessfully");
            }

            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return new AuthResponse(false, StatusCodes.Status400BadRequest, message: errors);
        }
    }
}
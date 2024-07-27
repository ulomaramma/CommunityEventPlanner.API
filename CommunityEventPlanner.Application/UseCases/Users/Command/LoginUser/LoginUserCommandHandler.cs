using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.Services;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using CommunityEventPlanner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Users.Command.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new AuthResponse(false, StatusCodes.Status400BadRequest, message: "Invalid email or password.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!result.Succeeded)
            {
                return new AuthResponse(false, StatusCodes.Status400BadRequest, message: "Invalid email or password.");
            }

            var token = await _authService.GenerateJwtToken(user);
            return new AuthResponse(true, StatusCodes.Status200OK, jwtToken: token, message: "User Logged in Sucessfully.");
        }

    }
}

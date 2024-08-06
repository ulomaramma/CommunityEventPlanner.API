using CommunityEventPlanner.Application.UseCases.Common.Models;
using CommunityEventPlanner.Application.UseCases.Users.Command.LoginUser;
using CommunityEventPlanner.Application.UseCases.Users.Command.RegisterUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.IntegrationTests
{
    public class UserIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public UserIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task SignUp_ShouldReturnSuccess()
        {
            // Arrange
            var command = new RegisterUserCommand
            {
                Email = "maggiluca@example.com",
                Password = "Password123!",
                FirstName = "maggi",
                LastName = "lucca"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/sign-up", command);
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

            // Assert
            Assert.True(apiResponse?.Success);
            Assert.Equal(StatusCodes.Status201Created, apiResponse?.Code);
            Assert.NotNull(apiResponse.JwtToken);
            Assert.Equal("User Registered Sucessfully", apiResponse.Message);


        }
        [Fact]
        public async Task Login_ShouldReturnSuccess()
        {
            // Arrange
            var command = new LoginUserCommand
            {
                Email = "maggiluca@example.com",
                Password = "Password123!",
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/login", command);
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

            // Assert
            Assert.True(apiResponse.Success);
            Assert.Equal(StatusCodes.Status200OK, apiResponse.Code);
            Assert.NotNull(apiResponse.JwtToken);
            Assert.Equal("User Logged in Successfully", apiResponse.Message);
        }
    }

}

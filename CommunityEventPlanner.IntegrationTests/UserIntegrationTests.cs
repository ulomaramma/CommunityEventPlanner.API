using CommunityEventPlanner.Application.UseCases.Common.Models;
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
    public class UserIntegrationTests : IntegrationTestBase
    {
        public UserIntegrationTests(WebApplicationFactory<Program> factory) : base(factory)
        {

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
            Assert.NotEmpty(apiResponse.JwtToken);
            Assert.Equal("User Registered Sucessfully", apiResponse.Message);


        }
    }
}

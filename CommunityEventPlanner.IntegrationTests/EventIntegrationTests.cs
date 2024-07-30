using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using CommunityEventPlanner.Application.UseCases.Events.Commands.CreateEvent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Xunit;
namespace CommunityEventPlanner.IntegrationTests
{
    public class EventIntegrationTests : IntegrationTestBase
    {
        public EventIntegrationTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task CreateEvent_ShouldReturnSuccess()
        {
            // Arrange
            var command = new CreateEventCommand
            {
                Title = "New Event",
                Description = "This is a new event.",
                StartDate = DateTime.UtcNow.AddDays(10),
                EndDate = DateTime.UtcNow.AddDays(11),
                StartTime = new TimeSpan(9, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Location = "Location A",
                IsPhysical = true,
                IsFree = true,
                Cost = 0,
                Capacity = 100
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/events", command);
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<EventDto>>();

            // Assert
            Assert.True(apiResponse.Success);
            Assert.Equal(StatusCodes.Status201Created, apiResponse.Code);
            Assert.NotNull(apiResponse.Data);
            Assert.Equal(command.Title, apiResponse.Data.Title);
        }

        [Fact]
        public async Task GetUpcomingEvents_ShouldReturnEvents()
        {
            // Act
            var response = await _client.GetAsync("/api/events/upcoming");
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<EventDto>>>();

            // Assert
            Assert.True(apiResponse.Success);
            Assert.Equal(StatusCodes.Status200OK, apiResponse.Code);
            Assert.NotNull(apiResponse.Data);
            Assert.True(apiResponse.Data.Any());
        }
    }
}

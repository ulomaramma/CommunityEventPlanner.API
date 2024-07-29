using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using CommunityEventPlanner.Application.Interfaces.Repositories;
using CommunityEventPlanner.Application.Interfaces;
using CommunityEventPlanner.Domain.Entities;
using Microsoft.AspNetCore.Http;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using CommunityEventPlanner.Application.UseCases.Events.Queries.GetUpcomingEvents;
namespace CommunityEventPlanner.UnitTests.Application.Queries
{
    public class GetUpcomingEventsQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IEventRepository> _eventRepositoryMock;

        public GetUpcomingEventsQueryHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventRepositoryMock = new Mock<IEventRepository>();
        }



        [Fact]
        public async Task Handle_ShouldReturnUpcomingEvents()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockEventRepository = new Mock<IEventRepository>();
            var currentDateTime = DateTime.UtcNow;

            var events = new List<Event>
            {
                new Event
                {
                    Title = "Upcoming Event 1",
                    Description = "This event is in the future.",
                    StartDate = currentDateTime.AddDays(5),
                    EndDate = currentDateTime.AddDays(6),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    Location = "Location B",
                    IsPhysical = false,
                    AccessLink = "https://example.com",
                    IsFree = false,
                    Cost = 50,
                    Capacity = 200
                },
                new Event
                {
                    Title = "Upcoming Event 2",
                    Description = "This event is also in the future.",
                    StartDate = currentDateTime.AddDays(15),
                    EndDate = currentDateTime.AddDays(16),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    Location = "Location C",
                    IsPhysical = true,
                    IsFree = true,
                    Cost = 0,
                    Capacity = 150
                }
            };

            mockEventRepository.Setup(repo => repo.GetUpcomingEventsAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(events);
            mockUnitOfWork.Setup(uow => uow.EventRepository).Returns(mockEventRepository.Object);

            var handler = new GetUpcomingEventsQueryHandler(mockUnitOfWork.Object);
            var query = new GetUpcomingEventsQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(StatusCodes.Status200OK, result.Code);
            Assert.NotNull(result.Data);
            Assert.Equal(2, result.Data.Count());
        }
    }
}

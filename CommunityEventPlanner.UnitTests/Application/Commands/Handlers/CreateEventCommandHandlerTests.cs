using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CommunityEventPlanner.Application.Interfaces.Repositories;
using CommunityEventPlanner.Application.Interfaces;
using CommunityEventPlanner.Domain.Entities;
using Microsoft.AspNetCore.Http;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.UseCases.Events.Commands.CreateEvent;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
namespace CommunityEventPlanner.UnitTests.Application.Commands.Handlers
{
    public class CreateEventCommandHandlerTests
    {

        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly  Mock<IEventRepository> _eventRepositoryMock;

        public CreateEventCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventRepositoryMock = new Mock<IEventRepository>();
        }

        [Fact]
        public async Task Handle_ShouldCreateEventAndReturnResponse()
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

            var newEvent = command.ToEventEntity();
            var eventDto = newEvent.ToEventDto();

            _eventRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Event>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(uow => uow.EventRepository).Returns(_eventRepositoryMock.Object);
            _unitOfWorkMock.Setup(uow => uow.CompleteAsync()).ReturnsAsync(1);

            var handler = new CreateEventCommandHandler(_unitOfWorkMock.Object);

           
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(StatusCodes.Status201Created, result.Code);
            Assert.NotNull(result.Data);
            Assert.Equal(eventDto.Title, result.Data.Title);
            Assert.Equal(eventDto.Description, result.Data.Description);
            Assert.Equal(eventDto.StartDate, result.Data.StartDate);
            Assert.Equal(eventDto.EndDate, result.Data.EndDate);
            Assert.Equal(eventDto.StartTime, result.Data.StartTime);
            Assert.Equal(eventDto.EndTime, result.Data.EndTime);
            Assert.Equal(eventDto.Location, result.Data.Location);
            Assert.Equal(eventDto.IsPhysical, result.Data.IsPhysical);
            Assert.Equal(eventDto.IsFree, result.Data.IsFree);
            Assert.Equal(eventDto.Cost, result.Data.Cost);
            Assert.Equal(eventDto.Capacity, result.Data.Capacity);
        }
    }
}

using CommunityEventPlanner.API.Models;
using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.UseCases.Events.Commands.CreateEvent;
using CommunityEventPlanner.Application.UseCases.Events.Queries.GetUpcomingEvents;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityEventPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command)
        {
            var eventDto = await _mediator.Send(command);
            var response = new ApiResponse<EventDto>(true, StatusCodes.Status200OK, eventDto, "Event Created Sucessfully");
            return Ok(response);
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            var eventDtos = await _mediator.Send(new GetUpcomingEventsQuery());
            var response = new ApiResponse<IEnumerable<EventDto>>(true, StatusCodes.Status200OK, eventDtos);
            return Ok(response);
        }
    }
}

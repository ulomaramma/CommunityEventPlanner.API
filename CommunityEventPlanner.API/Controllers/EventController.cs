﻿using CommunityEventPlanner.API.Models;
using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.UseCases.Events.Commands.AddEventAttendees;
using CommunityEventPlanner.Application.UseCases.Events.Commands.CreateEvent;
using CommunityEventPlanner.Application.UseCases.Events.Queries.GetUpcomingEvents;
using CommunityEventPlanner.Application.UseCases.Users.Command.GoogleSignIn;
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
            var response = await _mediator.Send(command);
            return StatusCode(response.Code, response);
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            var response = await _mediator.Send(new GetUpcomingEventsQuery());
            return StatusCode(response.Code, response);
        }

        [HttpPost("add-attendees")]
        public async Task<IActionResult> AddEventAttendees([FromBody] AddEventAttendeesCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.Code, response);
        }

       
    }
}
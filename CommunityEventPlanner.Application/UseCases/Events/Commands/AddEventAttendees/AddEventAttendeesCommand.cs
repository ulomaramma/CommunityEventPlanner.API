using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Events.Commands.AddEventAttendees
{
    public class AddEventAttendeesCommand : IRequest<ApiResponse<EventBookingDto>>
    {
        public int EventBookingId { get; set; }
        public List<EventAttendeeDto> Attendees { get; set; }
    }
}

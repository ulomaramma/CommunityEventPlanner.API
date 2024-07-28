using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using CommunityEventPlanner.Domain.Entities;
using CommunityEventPlanner.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.EventAttendees.Commands.AddEventAttendees
{
    public class AddEventAttendeesCommandHandler : IRequestHandler<AddEventAttendeesCommand, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddEventAttendeesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(AddEventAttendeesCommand request, CancellationToken cancellationToken)
        {
            var eventBooking = await _unitOfWork.EventBookings.GetByIdAsync(request.EventBookingId);
            if (eventBooking == null || eventBooking.Status == BookingStatus.Complete)
            {
                return new ApiResponse(false, StatusCodes.Status404NotFound, message: "Event booking not found or already completed.");
            }

            var eventAttendees = request.Attendees.Select(a => new EventAttendee
            {
                Name = a.Name,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                isContactPerson = a.IsContactPerson,
                EventBookingId = request.EventBookingId
            }).ToList();

            foreach (var attendee in eventAttendees)
            {
                eventBooking.EventAttendees.Add(attendee);
            }

            await _unitOfWork.CompleteAsync();

            var eventBookingDto = eventBooking.ToEventBookingDto();

            return new ApiResponse(true, StatusCodes.Status200OK, eventBookingDto);
        }
    }
}

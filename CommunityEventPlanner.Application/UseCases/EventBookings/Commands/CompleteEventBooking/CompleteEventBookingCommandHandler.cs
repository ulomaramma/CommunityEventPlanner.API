using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using CommunityEventPlanner.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.EventBookings.Commands.CompleteEventBooking
{
    public class CompleteEventBookingCommandHandler : IRequestHandler<CompleteEventBookingCommand, ApiResponse<EventBookingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteEventBookingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<EventBookingDto>> Handle(CompleteEventBookingCommand request, CancellationToken cancellationToken)
        {
            var eventBooking = await _unitOfWork.EventBookings.GetByIdAsync(request.EventBookingId);
            if (eventBooking == null || eventBooking.Status == BookingStatus.Complete)
            {
                return new ApiResponse<EventBookingDto>(false, StatusCodes.Status404NotFound, errorMessage: "Event booking not found or already completed.");
            }

            eventBooking.Status = BookingStatus.Complete;
            await _unitOfWork.CompleteAsync();

            var eventBookingDto = eventBooking.ToEventBookingDto();

            return new ApiResponse<EventBookingDto>(true, StatusCodes.Status200OK, eventBookingDto);
        }
    }
}

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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Events.Commands.StartEventBooking
{
    public class StartEventBookingCommandHandler : IRequestHandler<StartEventBookingCommand, ApiResponse<EventBookingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StartEventBookingCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<EventBookingDto>> Handle(StartEventBookingCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _unitOfWork.Events.GetByIdAsync(request.EventId);
            if (eventEntity == null)
            {
                return new ApiResponse<EventBookingDto>(false, StatusCodes.Status404NotFound, errorMessage: "Event not found.");
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var eventBooking = new EventBooking
            {
                EventId = request.EventId,
                UserId = userId,
                NumberOfTickets = request.NumberOfTickets,
                BookingDate = DateTime.UtcNow,
                Subtotal = eventEntity.Cost * request.NumberOfTickets,
                Total = eventEntity.Cost * request.NumberOfTickets,
                Status = BookingStatus.Incomplete,
            };

            await _unitOfWork.EventBookings.AddAsync(eventBooking);
            await _unitOfWork.CompleteAsync();

            var eventBookingDto = eventBooking.ToEventBookingDto();

            return new ApiResponse<EventBookingDto>(true, StatusCodes.Status201Created, eventBookingDto);
        }
    }
}

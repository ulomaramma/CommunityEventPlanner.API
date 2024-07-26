using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.EventBookings.Queries.GetIncompleteBookings
{
    public class GetIncompleteBookingsQueryHandler : IRequestHandler<GetIncompleteBookingsQuery, ApiResponse<IEnumerable<EventBookingDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetIncompleteBookingsQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<IEnumerable<EventBookingDto>>> Handle(GetIncompleteBookingsQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var incompleteBookings = await _unitOfWork.EventBookings.GetIncompleteBookingsByUserIdAsync(userId);

            var bookingDtos = incompleteBookings.Select(eb => eb.ToEventBookingDto());

            return new ApiResponse<IEnumerable<EventBookingDto>>(true, StatusCodes.Status200OK, bookingDtos);
        }
    }
}

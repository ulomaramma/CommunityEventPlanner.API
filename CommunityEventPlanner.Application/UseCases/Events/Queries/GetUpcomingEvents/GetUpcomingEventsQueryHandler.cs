using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Events.Queries.GetUpcomingEvents
{
    public class GetUpcomingEventsQueryHandler : IRequestHandler<GetUpcomingEventsQuery, ApiResponse<IEnumerable<EventDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUpcomingEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task <ApiResponse<IEnumerable<EventDto>>> Handle(GetUpcomingEventsQuery request, CancellationToken cancellationToken)
        {
            var upcomingEvents = await _unitOfWork.EventRepository.GetUpcomingEventsAsync(DateTime.UtcNow);
            var eventDtos = upcomingEvents.Select(e => e.ToEventDto());
            return new ApiResponse<IEnumerable< EventDto>>(true,StatusCodes.Status200OK,eventDtos);
        }
    }
}

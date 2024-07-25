using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Events.Queries.GetUpcomingEvents
{
    public class GetUpcomingEventsQueryHandler : IRequestHandler<GetUpcomingEventsQuery, IEnumerable<EventDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUpcomingEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventDto>> Handle(GetUpcomingEventsQuery request, CancellationToken cancellationToken)
        {
            var upcomingEvents = await _unitOfWork.Events.GetUpcomingEventsAsync(DateTime.UtcNow);       
            return upcomingEvents.Select(e => e.ToEventDto());
        }
    }
}

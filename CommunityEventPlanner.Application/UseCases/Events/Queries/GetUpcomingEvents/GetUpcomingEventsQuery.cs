using CommunityEventPlanner.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Events.Queries.GetUpcomingEvents
{
    public class GetUpcomingEventsQuery : IRequest<IEnumerable<EventDto>>
    {
    }
}

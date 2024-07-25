using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Interfaces.Repositories
{
    public interface IEventOccurrenceRepository: IGenericRepository<EventOccurrence>
    {
        Task<IEnumerable<EventOccurrence>> GetOccurrencesByEventIdAsync(int eventId);
        Task<EventOccurrence> GetOccurrenceWithDetailsAsync(int occurrenceId);
    }
}

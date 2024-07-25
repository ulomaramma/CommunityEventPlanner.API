using CommunityEventPlanner.Application.Interfaces.Repositories;
using CommunityEventPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Infrastructure.DataAccess.Repositories
{
    public class EventOccurrenceRepository: GenericRepository<EventOccurrence>, IEventOccurrenceRepository
    {
        public EventOccurrenceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EventOccurrence>> GetOccurrencesByEventIdAsync(int eventId)
        {
            return await _context.EventOccurrences
                .Where(eo => eo.EventId == eventId)
                .ToListAsync();
        }

        public async Task<EventOccurrence> GetOccurrenceWithDetailsAsync(int occurrenceId)
        {
            return await _context.EventOccurrences
                .Include(eo => eo.Event)
                .FirstOrDefaultAsync(eo => eo.EventOccurrenceId == occurrenceId);
        }
    }
}

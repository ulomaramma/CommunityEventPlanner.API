using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityEventPlanner.Application.Interfaces.Repositories;
using CommunityEventPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace CommunityEventPlanner.Infrastructure.DataAccess.Repositories
{
    public class EventRepository:GenericRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync(DateTime date)
        {
            return await _context.Events
                .Where(e => e.StartDate >= date)
                .ToListAsync();
        }
    }
}

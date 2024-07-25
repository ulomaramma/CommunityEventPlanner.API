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
    public class EventAttendeeRepository:GenericRepository<EventAttendee>, IEventAttendeeRepository
    {
        public EventAttendeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EventAttendee>> GetAttendeesByBookingIdAsync(int eventBookingId)
        {
            return await _context.EventAttendees
                .Where(ea => ea.EventBookingId == eventBookingId)
                .ToListAsync();
        }

        public async Task<EventAttendee> GetContactPersonByBookingIdAsync(int eventBookingId)
        {
            return await _context.EventAttendees
                .Where(ea => ea.EventBookingId == eventBookingId && ea.isContactPerson)
                .FirstOrDefaultAsync();
        }
    }
}

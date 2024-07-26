using CommunityEventPlanner.Application.Interfaces.Repositories;
using CommunityEventPlanner.Domain.Entities;
using CommunityEventPlanner.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Infrastructure.DataAccess.Repositories
{
    public class EventBookingRepository:GenericRepository<EventBooking>, IEventBookingRepository
    {
        public EventBookingRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<EventBooking>> GetBookingsByUserIdAsync(string userId)
        {
            return await _context.EventBookings
                .Where(eb => eb.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<EventBooking>> GetBookingsByEventIdAsync(int eventId)
        {
            return await _context.EventBookings
                .Where(eb => eb.EventId == eventId)
                .ToListAsync();
        }

        public async Task<EventBooking> GetBookingWithDetailsAsync(int bookingId)
        {
            return await _context.EventBookings
                .Include(eb => eb.EventAttendees)
                .FirstOrDefaultAsync(eb => eb.EventBookingId == bookingId);
        }
        public async Task<IEnumerable<EventBooking>> GetIncompleteBookingsByUserIdAsync(string userId)
        {
            return await _context.EventBookings
                .Where(eb => eb.UserId == userId && eb.Status == BookingStatus.Incomplete)
                .ToListAsync();
        }
    }
}

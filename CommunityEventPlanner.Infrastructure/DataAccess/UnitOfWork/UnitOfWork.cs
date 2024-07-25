using CommunityEventPlanner.Application.Interfaces.Repositories;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using CommunityEventPlanner.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Infrastructure.DataAccess.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Events = new EventRepository(_context);
            Users = new UserRepository(_context);
            EventBookings = new EventBookingRepository(_context);
            CustomUserLogins = new CustomUserLoginRepository(_context);
            EventAttendees = new EventAttendeeRepository(_context);
            EventOccurrences = new EventOccurrenceRepository(_context);
            Tickets = new TicketRepository(_context);
        }

        public IEventRepository Events { get; private set; }
        public IUserRepository Users { get; private set; }
        public IEventBookingRepository EventBookings { get; private set; }
        public ICustomUserLoginRepository CustomUserLogins { get; private set; }
        public IEventAttendeeRepository EventAttendees { get; private set; }
        public IEventOccurrenceRepository EventOccurrences { get; private set; }
        public ITicketRepository Tickets { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

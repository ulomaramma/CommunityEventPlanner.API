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
            EventRepository = new EventRepository(_context);
            UserRepository = new UserRepository(_context);
            EventBookingRepository = new EventBookingRepository(_context);
            CustomUserLoginRepository = new CustomUserLoginRepository(_context);
            EventAttendeeRepository = new EventAttendeeRepository(_context);
            EventOccurrencesRepository = new EventOccurrenceRepository(_context);
            TicketsRepository = new TicketRepository(_context);
        }

        public IEventRepository EventRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IEventBookingRepository EventBookingRepository { get; private set; }
        public ICustomUserLoginRepository CustomUserLoginRepository { get; private set; }
        public IEventAttendeeRepository EventAttendeeRepository { get; private set; }
        public IEventOccurrenceRepository EventOccurrencesRepository { get; private set; }
        public ITicketRepository TicketsRepository { get; private set; }

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

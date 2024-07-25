using CommunityEventPlanner.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Interfaces.UnitofWork
{
    public interface IUnitOfWork: IDisposable
    {
        IEventRepository Events { get; }
        IUserRepository Users { get; }
        IEventBookingRepository EventBookings { get; }
        ICustomUserLoginRepository CustomUserLogins { get; }
        IEventAttendeeRepository EventAttendees { get; }
        IEventOccurrenceRepository EventOccurrences { get; }
        ITicketRepository Tickets { get; }

        Task<int> CompleteAsync();
    }
}

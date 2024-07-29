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
        IEventRepository EventRepository { get; }
        IUserRepository UserRepository { get; }
        IEventBookingRepository EventBookingRepository { get; }
        ICustomUserLoginRepository CustomUserLoginRepository { get; }
        IEventAttendeeRepository EventAttendeeRepository { get; }
        IEventOccurrenceRepository EventOccurrencesRepository { get; }
        ITicketRepository TicketsRepository { get; }

        Task<int> CompleteAsync();
    }
}

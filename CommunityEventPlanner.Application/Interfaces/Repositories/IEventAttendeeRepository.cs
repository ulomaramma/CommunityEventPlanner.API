using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Interfaces.Repositories
{
    public interface IEventAttendeeRepository:IGenericRepository<EventAttendee>
    {
        Task<IEnumerable<EventAttendee>> GetAttendeesByBookingIdAsync(int eventBookingId);
        Task<EventAttendee> GetContactPersonByBookingIdAsync(int eventBookingId);
    }
}

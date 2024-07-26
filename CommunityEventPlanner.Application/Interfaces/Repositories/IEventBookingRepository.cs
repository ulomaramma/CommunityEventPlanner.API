using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Interfaces.Repositories
{
    public interface IEventBookingRepository: IGenericRepository<EventBooking>
    {
        Task<IEnumerable<EventBooking>> GetBookingsByUserIdAsync(string userId);
        Task<IEnumerable<EventBooking>> GetBookingsByEventIdAsync(int ticketId);
        Task<EventBooking> GetBookingWithDetailsAsync(int bookingId);
        Task<IEnumerable<EventBooking>> GetIncompleteBookingsByUserIdAsync(string userId);

    }
}

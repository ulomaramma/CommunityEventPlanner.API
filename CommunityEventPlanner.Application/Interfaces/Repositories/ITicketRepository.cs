using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Interfaces.Repositories
{
    public interface ITicketRepository: IGenericRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsByEventIdAsync(int eventId);
        Task<IEnumerable<Ticket>> GetTicketsByCategoryIdAsync(int ticketCategoryId);
    }
}

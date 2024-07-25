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
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByEventIdAsync(int eventId)
        {
            return await _context.Tickets
                .Where(t => t.EventId == eventId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByCategoryIdAsync(int ticketCategoryId)
        {
            return await _context.Tickets
                .Where(t => t.TicketCategoryId == ticketCategoryId)
                .ToListAsync();
        }

    }
}

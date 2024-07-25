using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Domain.Entities
{
    public class Ticket: BaseEntity
    {
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int TotalTickets { get; set; }
        public int AvailableTickets { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int TicketCategoryId { get; set; }
        public TicketCategory TicketCategory { get; set; }

    }
}

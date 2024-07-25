using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Domain.Entities
{
    public class TicketCategory: BaseEntity
    {
        public int TicketCategoryId { get; set; }
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}

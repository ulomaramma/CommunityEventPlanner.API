using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Domain.Entities
{
    public class EventCategory : BaseEntity
    {
        public int EventCategoryId { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }

    }
}

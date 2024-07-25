using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Domain.Entities
{
    public class EventOccurrence : BaseEntity
    {
        public int EventOccurrenceId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public DateTime OccurrenceDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

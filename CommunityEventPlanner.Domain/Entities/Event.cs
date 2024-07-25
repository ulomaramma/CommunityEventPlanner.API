using CommunityEventPlanner.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Domain.Entities
{
    public class Event: BaseEntity
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; } 
        public string Location { get; set; }
        public bool IsPhysical { get; set; }
        public string AccessLink { get; set; }
        public bool IsFree { get; set; }
        public decimal Cost { get; set; }
        public int Capacity { get; set; }
        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
        public EventType EventType { get; set; }
        public EventStatus EventStatus { get; set; } 
        public List<EventBooking> EventBookings { get; set; }
        public List<EventOccurrence> EventOccurrences { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}

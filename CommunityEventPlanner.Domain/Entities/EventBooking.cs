using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Domain.Entities
{
    public class EventBooking :BaseEntity
    {
        public int EventBookingId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<EventAttendee> EventAttendees { get; set; }
    }
}

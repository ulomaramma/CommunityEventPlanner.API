using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Domain.Entities
{
    public class EventAttendee: BaseEntity
    {
        public int EventAttendeeId { get; set; }
        public int EventBookingId { get; set; }
        public EventBooking EventBooking { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool isContactPerson { get; set; }

    }
}

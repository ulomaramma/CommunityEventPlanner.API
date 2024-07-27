using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

        public List<CustomeUserLogin> CustomeUserLogins { get; set; }
        public List<EventBooking> EventBookings { get; set; }
        public List<Event> Events { get; set; }

    }
}

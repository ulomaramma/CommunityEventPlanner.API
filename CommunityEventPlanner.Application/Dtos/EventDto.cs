using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Dtos
{
    public class EventDto
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
        public string ImageUrl { get; set; }
        public bool IsFree { get; set; }
        public decimal Cost { get; set; }
        public int Capacity { get; set; }
    }
}

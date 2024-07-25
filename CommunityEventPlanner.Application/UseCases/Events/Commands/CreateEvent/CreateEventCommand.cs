using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<EventDto>
    {
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
        public int EventCategoryId { get; set; }
        public string UserId { get; set; }
        public EventType EventType { get; set; }
        public EventStatus EventStatus { get; set; }
    }
}

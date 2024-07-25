using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.UseCases.Events.Commands.CreateEvent;
using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Extensions.MappingExtensions
{
    public static class EventMappingExtensions
    {
        public static EventDto ToEventDto(this Event eventEntity)
        {
            return new EventDto
            {
                EventId = eventEntity.EventId,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartDate = eventEntity.StartDate,
                EndDate = eventEntity.EndDate,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime,
                Location = eventEntity.Location,
                IsPhysical = eventEntity.IsPhysical,
                AccessLink = eventEntity.AccessLink,
                ImageUrl = eventEntity.ImageUrl,
                IsFree = eventEntity.IsFree,
                Cost = eventEntity.Cost,
                Capacity = eventEntity.Capacity
            };
        }
        public static Event ToEventEntity(this CreateEventCommand command)
        {
            return new Event
            {
                Title = command.Title,
                Description = command.Description,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                StartTime = command.StartTime,
                EndTime = command.EndTime,
                Location = command.Location,
                IsPhysical = command.IsPhysical,
                AccessLink = command.AccessLink,
                ImageUrl = command.ImageUrl,
                IsFree = command.IsFree,
                Cost = command.Cost,
                Capacity = command.Capacity,
                EventCategoryId = command.EventCategoryId,
                UserId = command.UserId,
                EventType = command.EventType,
                EventStatus = command.EventStatus
            };
        }
    }
}

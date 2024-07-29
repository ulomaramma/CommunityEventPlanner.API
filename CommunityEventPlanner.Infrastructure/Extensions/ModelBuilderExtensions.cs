using CommunityEventPlanner.Domain.Entities;
using CommunityEventPlanner.Domain.Enum;
using CommunityEventPlanner.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CommunityEventPlanner.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>().HasData(
                new EventCategory { EventCategoryId = 1, Name = "Conference" },
                new EventCategory { EventCategoryId = 2, Name = "Workshop" },
                new EventCategory { EventCategoryId = 3, Name = "Seminar" },
                new EventCategory { EventCategoryId = 4, Name = "Meetup" }
            );

            // Seed Events
            var random = new Random();
            var startDateBase = new DateTime(2024, 8, 1);
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    Title = "Tech Conference 2024",
                    Description = "Annual tech conference covering the latest in technology.",
                    StartDate = startDateBase.AddDays(random.Next(0, 30)),
                    EndDate = startDateBase.AddDays(random.Next(31, 60)),
                    StartTime = new TimeSpan(random.Next(8, 11), 0, 0),
                    EndTime = new TimeSpan(random.Next(17, 20), 0, 0),
                    Location = "New York Convention Center",
                    IsPhysical = true,
                    AccessLink = string.Empty,
                    ImageUrl = string.Empty,
                    IsFree = false,
                    Cost = 299.99M,
                    Capacity = 500,
                    EventCategoryId = 1,
                    UserId = null, // Add a valid UserId 
                    EventType = EventType.Single,
                    EventStatus = EventStatus.Published
                },
                new Event
                {
                    EventId = 2,
                    Title = "Online Workshop on AI",
                    Description = "Interactive online workshop on artificial intelligence.",
                    StartDate = startDateBase.AddDays(random.Next(0, 30)),
                    EndDate = startDateBase.AddDays(random.Next(31, 60)),
                    StartTime = new TimeSpan(random.Next(8, 11), 0, 0),
                    EndTime = new TimeSpan(random.Next(17, 20), 0, 0),
                    Location = "Online",
                    IsPhysical = false,
                    AccessLink = "https://meet.google.com/oaf-ernz-mxi?hs=122&authuser=0",
                    ImageUrl = string.Empty,
                    IsFree = true,
                    Cost = 0M,
                    Capacity = 1000,
                    EventCategoryId = 2,
                    UserId = null, // Add a valid UserId 
                    EventType = EventType.Single,
                    EventStatus = EventStatus.Published
                }
            );
        }
    }
}

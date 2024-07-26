using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Extensions.MappingExtensions
{
    public static class EventBookingMappingExtensions
    {
        public static EventBookingDto ToEventBookingDto(this EventBooking eventBooking)
        {
            return new EventBookingDto
            {
                EventBookingId = eventBooking.EventBookingId,
                EventId = eventBooking.EventId,
                UserId = eventBooking.UserId,
                BookingDate = eventBooking.BookingDate,
                NumberOfTickets = eventBooking.NumberOfTickets,
                Subtotal = eventBooking.Subtotal,
                Total = eventBooking.Total
            };
        }
    }
}

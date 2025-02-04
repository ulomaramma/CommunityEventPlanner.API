﻿using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.UseCases.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.EventBookings.Commands.StartEventBooking
{
    public class StartEventBookingCommand : IRequest<ApiResponse<EventBookingDto>>
    {
        public int EventId { get; set; }
        public int NumberOfTickets { get; set; }
    }
}

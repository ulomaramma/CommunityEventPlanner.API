using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Application.Extensions.MappingExtensions;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.UseCases.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = request.ToEventEntity();
            await _unitOfWork.Events.AddAsync(newEvent);
            await _unitOfWork.CompleteAsync();
            return newEvent.ToEventDto();
        }


    }
}

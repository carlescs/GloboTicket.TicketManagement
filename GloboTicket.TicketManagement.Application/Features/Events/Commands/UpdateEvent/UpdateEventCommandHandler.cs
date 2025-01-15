using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
    : IRequestHandler<UpdateEventCommand>
{
    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await eventRepository.GetByIdAsync(request.EventId);
        if(eventToUpdate == null)
            throw new NotFoundException(nameof(Event), request.EventId);

        mapper.Map(request, eventToUpdate);
        await eventRepository.UpdateAsync(eventToUpdate);
    }
}
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler(IEventRepository eventRepository)
    : IRequestHandler<DeleteEventCommand>
{

    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await eventRepository.GetByIdAsync(request.EventId);
        if (eventToDelete == null)
            throw new NotFoundException(nameof(Event), request.EventId);

        await eventRepository.DeleteAsync(eventToDelete);
    }
}
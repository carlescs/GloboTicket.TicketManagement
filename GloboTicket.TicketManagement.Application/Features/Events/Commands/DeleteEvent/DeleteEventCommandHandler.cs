using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler(IEventRepository eventRepository)
    : IRequestHandler<DeleteEventCommand>
{

    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await eventRepository.GetByIdAsync(request.EventId);
        await eventRepository.DeleteAsync(eventToDelete);
    }
}
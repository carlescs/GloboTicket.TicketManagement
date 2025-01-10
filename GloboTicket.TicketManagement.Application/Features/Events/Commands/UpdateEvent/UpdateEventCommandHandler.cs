using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
    : IRequestHandler<UpdateEventCommand>
{
    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await eventRepository.GetByIdAsync(request.EventId);
        
        mapper.Map(request, eventToUpdate);
        await eventRepository.UpdateAsync(eventToUpdate);
    }
}
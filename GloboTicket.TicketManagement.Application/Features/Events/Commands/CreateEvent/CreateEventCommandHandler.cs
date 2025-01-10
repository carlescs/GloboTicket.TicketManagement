using AutoMapper;
using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IValidator<CreateEventCommand> validator)
    : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = mapper.Map<Event>(request);

        var validationResults = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResults.IsValid)
            throw new ValidationException(validationResults.Errors);

        @event = await eventRepository.AddAsync(@event);
        return @event.EventId;
    }
}
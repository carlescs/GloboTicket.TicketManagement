using AutoMapper;
using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(IEventRepository eventRepository, IEMailService eMailService, IMapper mapper, IValidator<CreateEventCommand> validator)
    : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = mapper.Map<Event>(request);

        var validationResults = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResults.IsValid)
            throw new ValidationException(validationResults.Errors);

        @event = await eventRepository.AddAsync(@event);

        var eMail = new Email
        {
            To = "carlescs@gmail.com",
            Subject = "A new event was created",
            Body = $"A new event was created: {request}"
        };

        try
        {
            await eMailService.SendEmail(eMail);
        }
        catch (Exception)
        {
            // log or manage the exception
        }

        return @event.EventId;
    }
}
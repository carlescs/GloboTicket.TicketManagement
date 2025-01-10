using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;

public record DeleteEventCommand(Guid EventId) : IRequest;
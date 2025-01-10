using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;

public record GetEventDetailQuery(Guid EventId) : IRequest<EventDetailVm>;
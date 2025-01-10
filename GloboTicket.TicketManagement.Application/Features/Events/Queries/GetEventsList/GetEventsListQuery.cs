using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;

public record GetEventsListQuery : IRequest<List<EventListVm>>;
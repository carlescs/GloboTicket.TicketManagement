using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public record GetEventsExportQuery : IRequest<EventExportFileVm>;
}

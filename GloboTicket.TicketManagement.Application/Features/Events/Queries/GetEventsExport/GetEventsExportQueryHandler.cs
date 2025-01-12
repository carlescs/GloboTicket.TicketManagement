using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

public class GetEventsExportQueryHandler(IEventRepository eventRepository, IMapper mapper, ICsvExporter csvExporter)
    : IRequestHandler<GetEventsExportQuery, EventExportFileVm>
{
    public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
    {
        var allEvents= mapper.Map<List<EventExportDto>>((await eventRepository.ListAllAsync()).OrderBy(t=>t.Date));
        var fileData = csvExporter.ExportEventsToCsv(allEvents);
        var eventExportFileDto = new EventExportFileVm() { ContentType = "text/csv", Data = fileData, EventExportFileName = $"{Guid.NewGuid()}.csv" };

        return eventExportFileDto;
    }
}

public class EventExportDto
{
}
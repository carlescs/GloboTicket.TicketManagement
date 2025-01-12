namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

public class EventExportFileVm
{
    public byte[] Data { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string? EventExportFileName { get; set; }
}
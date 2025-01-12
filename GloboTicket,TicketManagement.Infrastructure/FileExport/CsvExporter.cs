using System.Globalization;
using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace GloboTicket_TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter  : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> events)
        {
            using var memoryStream = new MemoryStream();
            using var streamWriter = new StreamWriter(memoryStream);
            using var csvWriter=new CsvWriter(streamWriter,CultureInfo.InvariantCulture);
            csvWriter.WriteRecordsAsync(events);
            return memoryStream.ToArray();
        }
    }
}

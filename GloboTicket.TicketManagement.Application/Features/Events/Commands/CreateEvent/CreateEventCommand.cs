using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public record CreateEventCommand : IRequest<Guid>
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public string Artist { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public Guid CategoryId { get; set; }
}
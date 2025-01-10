using System.ComponentModel.DataAnnotations;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public record UpdateEventCommand : IRequest
{
    public Guid EventId { get; init; }
    public string Name { get; init; } = null!;
    public int Price { get; init; }
    public string Artist { get; set; } = null!;
    public DateTime Date { get; init; }
    public string ImageUrl { get; init; } = null!;
    public string Description { get; init; } = null!;
    public Guid CategoryId { get; init; }
}
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; } = null!;
}
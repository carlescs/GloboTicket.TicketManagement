namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandResponse
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; } = null!;
}
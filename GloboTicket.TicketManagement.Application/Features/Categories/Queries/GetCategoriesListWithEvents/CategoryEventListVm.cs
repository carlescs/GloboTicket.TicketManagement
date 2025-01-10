namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public class CategoryEventListVm
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<CategoryEventDto> Events { get; set; } = [];
}
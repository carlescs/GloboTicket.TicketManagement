using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public record GetCatergoriesListQuery : IRequest<List<CategoryListVm>>;
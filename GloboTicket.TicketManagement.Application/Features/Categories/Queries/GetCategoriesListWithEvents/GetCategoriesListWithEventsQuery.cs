using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public record GetCategoriesListWithEventsQuery(bool IncludeHistory) : IRequest<List<CategoryEventListVm>>;

public class GetCategoriesListWithEventsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
{
    public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
        return mapper.Map<List<CategoryEventListVm>>(categories);
    }
}
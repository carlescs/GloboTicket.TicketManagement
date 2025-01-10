using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCatergoriesListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
    : IRequestHandler<GetCatergoriesListQuery, List<CategoryListVm>>
{
    public async Task<List<CategoryListVm>> Handle(GetCatergoriesListQuery request, CancellationToken cancellationToken)
    {
        var allCategories = (await categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
        return mapper.Map<List<CategoryListVm>>(allCategories);
    }
}
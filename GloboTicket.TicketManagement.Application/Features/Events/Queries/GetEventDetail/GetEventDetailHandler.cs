using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailHandler(IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository, IMapper mapper) : IRequestHandler<GetEventDetailQuery, EventDetailVm>
{
    public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.EventId);
        var eventDetailDto = mapper.Map<EventDetailVm>(@event);

        var category = await categoryRepository.GetByIdAsync(@event.CategoryId);
        eventDetailDto.Category = mapper.Map<CategoryDto>(category);

        return eventDetailDto;
    }
}
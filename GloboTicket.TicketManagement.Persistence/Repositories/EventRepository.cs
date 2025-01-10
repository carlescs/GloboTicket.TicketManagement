using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories;

public class EventRepository(GloboTicketDbContext dbContext) : BaseRepository<Event>(dbContext), IEventRepository
{
    private readonly GloboTicketDbContext _dbContext = dbContext;

    public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
    {
        return await _dbContext.Events.AnyAsync(e => e.Name == name && e.Date.Date == eventDate.Date);
    }
}
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories;

public class CategoryRepository(GloboTicketDbContext dbContext) : BaseRepository<Category>(dbContext), ICategoryRepository
{
    private readonly GloboTicketDbContext _dbContext = dbContext;

    public Task<List<Category>> GetCategoriesWithEvents(bool requestIncludeHistory)
    {
        IQueryable<Category> categories=_dbContext.Categories
            .Include(x => x.Events);

        return categories.Select(t => new Category
        {
            CategoryId = t.CategoryId,
            Name = t.Name,
            Events = requestIncludeHistory ? t.Events : t.Events.Where(e => e.Date >= DateTime.Today).ToList(),
            CreatedBy = t.CreatedBy,
            CreatedDate = t.CreatedDate,
            LastModifiedBy = t.LastModifiedBy,
            LastModifiedDate = t.LastModifiedDate
        }).ToListAsync();
    }
}
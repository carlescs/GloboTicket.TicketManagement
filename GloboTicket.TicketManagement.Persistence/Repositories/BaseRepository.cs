using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class BaseRepository<T>(GloboTicketDbContext dbContext) : IAsyncRepository<T> where T : class
    {
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return dbContext.SaveChangesAsync();
        }
    }
}

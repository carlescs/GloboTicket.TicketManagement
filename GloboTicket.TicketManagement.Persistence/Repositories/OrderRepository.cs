using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Persistence.Repositories;

public class OrderRepository(GloboTicketDbContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
{
}
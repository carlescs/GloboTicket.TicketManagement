using GloboTicket.TicketManagement.Application.Models.Mail;

namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure;

public interface IEMailService
{
    Task<bool> SendEmail(Email email);
}
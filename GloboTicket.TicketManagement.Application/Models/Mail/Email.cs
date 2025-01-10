namespace GloboTicket.TicketManagement.Application.Models.Mail;

public class Email
{
    public string To { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
}
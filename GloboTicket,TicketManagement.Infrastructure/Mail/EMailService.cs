using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GloboTicket_TicketManagement.Infrastructure.Mail;

public class EMailService(IOptions<EMailSettings> mailSettings) : IEMailService
{
    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(mailSettings.Value.ApiKey);
        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var body = email.Body;
        var from = new EmailAddress(mailSettings.Value.FromAddress, mailSettings.Value.FromName);
        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        var response= await client.SendEmailAsync(sendGridMessage);
        return response.StatusCode is System.Net.HttpStatusCode.OK or System.Net.HttpStatusCode.Accepted;
    }
}
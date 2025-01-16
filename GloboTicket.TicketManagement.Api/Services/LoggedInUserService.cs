using System.Security.Claims;
using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.Api.Services
{
    public class LoggedInUserService(IHttpContextAccessor httpContextAccessor) : ILoggedInUserService
    {
        public string? UserId => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

using FluentValidation.Results;

namespace GloboTicket.TicketManagement.Application.Exceptions;

public class ValidationException
{
    public List<string> ValidationErrors { get; set; }

    public ValidationException(ValidationResult validationResult)
    {
        ValidationErrors = validationResult.Errors.Select(t => t.ErrorMessage).ToList();
    }
}
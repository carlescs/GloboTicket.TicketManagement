using AutoMapper;
using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; } = null!;
}

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CreateCategoryCommand> validator)
    : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);

        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResults.IsValid)
            throw new ValidationException(validationResults.Errors);

        category = await categoryRepository.AddAsync(category);
        return mapper.Map<CreateCategoryCommandResponse>(category);
    }
}
using AutoMapper;
using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Profiles;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Commands;

public class CreateCategoryCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICategoryRepository> _categoriesRepositoryMock;
    private readonly IValidator<CreateCategoryCommand> _validator;
    public CreateCategoryCommandHandlerTests()
    {
        _categoriesRepositoryMock = RepositoryMocks.GetCategoryRepositoryMock();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = configurationProvider.CreateMapper();
        _validator = new CreateCategoryCommandValidator();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddedToRepo()
    {
        var handler = new CreateCategoryCommandHandler(_categoriesRepositoryMock.Object, _mapper,_validator);

        await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

        var allCategories = await _categoriesRepositoryMock.Object.ListAllAsync();

        allCategories.Count.ShouldBe(3);
    }

    [Fact]
    public void Handle_InvalidCategory_ThrowsValidationException()
    {
        var handler = new CreateCategoryCommandHandler(_categoriesRepositoryMock.Object, _mapper, _validator);
        Should.Throw<ValidationException>(async () => await handler.Handle(new CreateCategoryCommand(), CancellationToken.None));
    }

}
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories;

public static class RepositoryMocks
{
    public static Mock<ICategoryRepository> GetCategoryRepositoryMock()
    {
        List<Category> categories =
        [
            new Category
            {
                CategoryId = Guid.Parse("{01269212-F0B7-49E3-B9F0-1929AB6B8A5F}"),
                Name = "Concerts"
            },
            new Category
            {
                CategoryId = Guid.Parse("{01269212-F0B7-49E3-B9F0-1929AB6B8A52}"),
                Name = "Musicals"
            }
        ];
        var mock = new Mock<ICategoryRepository>();
        mock.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);
        mock.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
        {
            categories.Add(category);
            return category;
        });
        return mock;
    }
}
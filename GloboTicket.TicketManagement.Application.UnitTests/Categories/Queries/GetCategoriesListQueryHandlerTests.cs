﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICategoryRepository> _mockCategoriesRepository;

    public GetCategoriesListQueryHandlerTests()
    {
        _mockCategoriesRepository=RepositoryMocks.GetCategoryRepositoryMock();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper= configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetCatergoriesListQueryHandler(_mockCategoriesRepository.Object,_mapper);

        var result= await handler.Handle(new GetCatergoriesListQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<CategoryListVm>>();
        result.Count.ShouldBe(2);
    }
}
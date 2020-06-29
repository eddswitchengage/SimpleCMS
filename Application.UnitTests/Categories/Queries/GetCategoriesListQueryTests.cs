using AutoMapper;
using Shouldly;
using SimpleCMS.Application.Categories.Queries.GetCategoriesList;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimpleCMS.Application.UnitTests.Categories.Queries
{
    [Collection("QueryTests")]
    public class GetCategoriesListQueryTests
    {
        private readonly ISimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCategoriesTest()
        {
            var queryHandler = new GetCategoriesListQueryHandler(_context, _mapper);

            var result = await queryHandler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<CategoriesListVM>();

            result.Categories.Count.ShouldBe(2);
        }
    }
}

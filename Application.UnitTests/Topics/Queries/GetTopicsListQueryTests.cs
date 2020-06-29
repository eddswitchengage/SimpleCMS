using AutoMapper;
using SimpleCMS.Application.Topics.Queries.GetTopicsList;
using SimpleCMS.Application.UnitTests.Common;
using SimpleCMS.Persistence;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Shouldly;

namespace SimpleCMS.Application.UnitTests.Topics.Queries
{
    [Collection("QueryTests")]
    public class GetTopicsListQueryTests
    {
        private readonly SimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetTopicsListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTopicsListTest()
        {
            var queryHandler = new GetTopicsListQueryHandler(_context, _mapper);

            var result = await queryHandler.Handle(new GetTopicsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<TopicsListVM>();
            result.Count.ShouldBe(2);
        }
    }
}

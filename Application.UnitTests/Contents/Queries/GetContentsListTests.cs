using AutoMapper;
using Shouldly;
using SimpleCMS.Application.Contents.Queries.GetContentDetail;
using SimpleCMS.Application.Contents.Queries.GetContentsList;
using SimpleCMS.Application.UnitTests.Common;
using SimpleCMS.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimpleCMS.Application.UnitTests.Contents.Queries
{
    [Collection("QueryTests")]
    public class GetContentsListTests
    {
        private readonly SimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetContentsListTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetContentsListTest()
        {
            var queryHandler = new GetContentsListQueryHandler(_context, _mapper);

            var result = await queryHandler.Handle(new GetContentsListQuery() { }, CancellationToken.None);

            result.ShouldBeOfType<ContentsListVM>();
            result.Count.ShouldBe(1);
        }
    }
}

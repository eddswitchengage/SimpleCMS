using AutoMapper;
using Shouldly;
using SimpleCMS.Application.Topics.Queries.Common;
using SimpleCMS.Application.Topics.Queries.GetTopicDetail;
using SimpleCMS.Application.UnitTests.Common;
using SimpleCMS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimpleCMS.Application.UnitTests.Topics.Queries
{
    [Collection("QueryTests")]
    public class GetTopicDetailQueryTests
    {
        private SimpleDbContext _context;
        private IMapper _mapper;

        public GetTopicDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTopicDetailTest()
        {
            var queryHandler = new GetTopicDetailQueryHandler(_context, _mapper);

            var result = await queryHandler.Handle(new GetTopicDetailQuery() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<TopicDetailVM>();
            result.Id.ShouldBe(1);
        }
    }
}

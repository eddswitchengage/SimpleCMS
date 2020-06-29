using AutoMapper;
using Shouldly;
using SimpleCMS.Application.Contents.Queries.GetContentDetail;
using SimpleCMS.Application.UnitTests.Common;
using SimpleCMS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimpleCMS.Application.UnitTests.Contents.Queries
{
    [Collection("QueryTests")]
    public class GetContentDetailQueryTests
    {
        private readonly SimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetContentDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetContentDetailTest()
        {
            var queryHandler = new GetContentDetailQueryHandler(_context, _mapper);

            var result = await queryHandler.Handle(new GetContentDetailQuery() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<ContentDetailVM>();
            result.Id.ShouldBe(1);
        }
    }
}

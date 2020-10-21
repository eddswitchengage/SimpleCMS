using AutoMapper;
using Shouldly;
using SimpleCMS.Application.Categories.Queries.Common;
using SimpleCMS.Application.Categories.Queries.GetCategoryDetail;
using SimpleCMS.Application.UnitTests.Common;
using SimpleCMS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimpleCMS.Application.UnitTests.Categories.Queries
{
    [Collection("QueryTests")]
    public class GetCategoryDetailQueryTests
    {
        private readonly SimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCategoryDetailTest()
        {
            var queryHandler = new GetCategoryDetailQueryHandler(_context, _mapper);

            var result = await queryHandler.Handle(new GetCategoryDetailQuery() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<CategoryDetailVM>();

            result.Id.ShouldBe(1);
        }
    }
}

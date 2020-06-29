using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleCMS.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public SimpleDbContext Context { get; private set; }

        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = SimpleCMSContextFactory.Create();

            var configurationProvider = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            SimpleCMSContextFactory.Dispose(Context);
        }
    }

    [CollectionDefinition("QueryTests")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }

}

using SimpleCMS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly SimpleDbContext _context;

        public CommandTestBase()
        {
            _context = SimpleCMSContextFactory.Create();
        }

        public void Dispose()
        {
            SimpleCMSContextFactory.Dispose(_context);
        }
    }
}

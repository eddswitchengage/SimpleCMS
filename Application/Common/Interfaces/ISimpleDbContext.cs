using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Common.Interfaces
{
    public interface ISimpleDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

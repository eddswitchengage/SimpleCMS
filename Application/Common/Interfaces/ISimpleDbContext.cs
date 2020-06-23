using Microsoft.EntityFrameworkCore;
using SimpleCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Common.Interfaces
{
    public interface ISimpleDbContext
    {
        DbSet<Content> Contents { get; set; }
        DbSet<Topic> Topics { get; set; }
        DbSet<Category> Categories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

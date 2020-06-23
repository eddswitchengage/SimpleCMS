using Microsoft.EntityFrameworkCore;
using SimpleCMS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCMS.Persistence
{
    public class SimpleDbContext : DbContext, ISimpleDbContext
    {
        public SimpleDbContext(DbContextOptions<SimpleDbContext> options) : base(options)
        {
        }
    }
}
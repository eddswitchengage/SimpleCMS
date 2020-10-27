using Microsoft.EntityFrameworkCore;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Common;
using SimpleCMS.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Persistence
{
    public class SimpleDbContext : DbContext, ISimpleDbContext
    {
        public SimpleDbContext(DbContextOptions<SimpleDbContext> options) : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //TODO: Once current user service has been implemented replace "UserId" with actual data

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "UserId";
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "UserId";
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Scans 'Configurations' folder and applies all configuration files found
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimpleDbContext).Assembly);
        }
    }
}
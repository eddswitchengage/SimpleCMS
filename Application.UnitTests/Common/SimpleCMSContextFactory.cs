using Microsoft.EntityFrameworkCore;
using SimpleCMS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.UnitTests.Common
{
    public class SimpleCMSContextFactory
    {
        public static SimpleDbContext Create()
        {
            var options = new DbContextOptionsBuilder<SimpleDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new SimpleDbContext(options);

            context.Database.EnsureCreated();

            Seed(context);

            return context;
        }

        private static void Seed(SimpleDbContext context)
        {
            context.Categories.AddRange(new Domain.Entities.Category[] {
                new Domain.Entities.Category(){CategoryId = 1, Name = "Non-empty Category"},
                new Domain.Entities.Category(){CategoryId = 2, Name = "Empty Category"},
            });

            context.Topics.AddRange(new Domain.Entities.Topic[]
            {
                new Domain.Entities.Topic() { CategoryId = 1, TopicId = 1, Name = "Non-empty Topic" },
                new Domain.Entities.Topic() { CategoryId = 1, TopicId = 2, Name = "Empty Topic" },
            });

            context.Contents.AddRange(new Domain.Entities.Content[]
            {
                new Domain.Entities.Content() { TopicId = 1, ContentId = 1, Name = "Content One" },
            });

            context.SaveChanges();
        }

        public static void Dispose(SimpleDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

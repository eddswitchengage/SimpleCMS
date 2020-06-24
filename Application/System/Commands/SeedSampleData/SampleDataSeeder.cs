using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.System.Commands.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly ISimpleDbContext _context;

        public SampleDataSeeder(ISimpleDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            await SeedCategoriesAsync(cancellationToken);
            await SeedTopicsAsync(cancellationToken);
            await SeedContentAsync(cancellationToken);
        }

        private async Task SeedCategoriesAsync(CancellationToken cancellationToken)
        {
            if (_context.Categories.Any()) return;

            _context.Categories.Add(new Category()
            {
                Name = "Category One",
                Description = "A simple category, it doesn't ask for much and lives within its means."
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedTopicsAsync(CancellationToken cancellationToken)
        {
            if (_context.Topics.Any()) return;

            int categoryId = _context.Categories.ToList()[0].CategoryId;

            _context.Topics.Add(new Topic()
            {
                CategoryId = categoryId,
                Name = "Topic One",
                Description = "This topic means business. There's no messing around when topic one is in town, that's for sure.",
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedContentAsync(CancellationToken cancellationToken)
        {
            if (_context.Contents.Any()) return;

            int topicId = _context.Topics.ToList()[0].TopicId;

            _context.Contents.Add(new Content()
            {
                TopicId = topicId,
                Name = "Simple Content",
                Description = "This guy really is simple, but otherwise harmless.",
            });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

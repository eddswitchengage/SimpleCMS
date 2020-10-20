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
                Title = "Uncategorised",
                Description = "Default category."
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
                Title = "Uncategorised",
                Description = "Default topic.",
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedContentAsync(CancellationToken cancellationToken)
        {
            if (_context.Contents.Any()) return;

            Topic defaultTopic = _context.Topics.First();

            _context.Contents.Add(new Content()
            {
                TopicId = defaultTopic.TopicId,
                Title = "Simple Content",
                Description = "This guy really is simple, but otherwise harmless.",
            });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

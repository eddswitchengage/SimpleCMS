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

            _context.Categories.Add(new Category()
            {
                Title = "Sample Category",
                Description = "A sample category containing sample topics."
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedTopicsAsync(CancellationToken cancellationToken)
        {
            if (_context.Topics.Any()) return;

            int uncategorisedCategoryId = _context.Categories.ToList()[0].CategoryId;

            int sampleCategoryId = _context.Categories.ToList()[1].CategoryId;

            _context.Topics.Add(new Topic()
            {
                CategoryId = uncategorisedCategoryId,
                Title = "Uncategorised",
                Description = "Default topic.",
            });

            _context.Topics.Add(new Topic()
            {
                CategoryId = sampleCategoryId,
                Title = "Sample Topic 1",
                Description = "Sample topic 1, containing some sample content."
            });
            _context.Topics.Add(new Topic()
            {
                CategoryId = sampleCategoryId,
                Title = "Sample Topic 2",
                Description = "Sample topic 2, containing some more sample content."
            });
            _context.Topics.Add(new Topic()
            {
                CategoryId = sampleCategoryId,
                Title = "Sample Topic 3",
                Description = "Sample topic 3, the final sample topic containing extra sample content"
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedContentAsync(CancellationToken cancellationToken)
        {
            if (_context.Contents.Any()) return;

            int uncategorisedTopicId = _context.Topics.Single(t => t.Title == "Uncategorised").TopicId;

            _context.Contents.Add(new Content()
            {
                TopicId = uncategorisedTopicId,
                Title = "Fresh Content",
                Description = "This content has just been created and is still to be categorised.",
            });

            for (var t = 1; t < 4; t++)
            {
                string topicName = $"Sample Topic {t}";
                int sampleTopicId = _context.Topics.Single(t => t.Title.Equals(topicName)).TopicId;

                for (var i = 0; i < 10; i++)
                {
                    _context.Contents.Add(new Content()
                    {
                        TopicId = sampleTopicId,
                        Title = $"Sample Content {i}",
                        Description = $"This is Sample Content {i} within the topic 'Sample Topic {t}'. "
                    });
                }
            }



            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Shouldly;
using SimpleCMS.Application.Categories.Commands.UpsertCategory;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimpleCMS.Application.UnitTests.Categories.Commands
{
    public class UpsertCategoryCommandTests : CommandTestBase
    {
        private readonly UpsertCategoryCommandHandler _handler;

        public UpsertCategoryCommandTests()
        {
            _handler = new UpsertCategoryCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenIdAndExists_UpdatesCategory()
        {
            var id = 1;
            var newDescription = "I have added this description";

            var command = new UpsertCategoryCommand() { Id = id, Title = "Non-empty category", Description = newDescription };
            await _handler.Handle(command, CancellationToken.None);

            var category = await _context.Categories.FindAsync(id);
            category.Description.ShouldBe(newDescription);
        }

        [Fact]
        public async Task Handle_GivenIdAndDoesntExist_ThrowsNotFoundException()
        {
            var id = 10;

            var command = new UpsertCategoryCommand() { Id = id, Title = "New Category", Description = "New category description" };

            await ShouldThrowAsyncExtensions.ShouldThrowAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_NotGivenId_CreatesCategory()
        {
            var categoryName = "New Category";
            var categoryDescription = "A brand new category";

            var command = new UpsertCategoryCommand() { Title = categoryName, Description = categoryDescription };

            await _handler.Handle(command, CancellationToken.None);

            var category = await _context.Categories.LastOrDefaultAsync();

            category.ShouldNotBe(null);
            category.Title.ShouldBe(categoryName);
            category.Description.ShouldBe(categoryDescription);
        }
    }
}

using FluentValidation.Validators;
using Shouldly;
using SimpleCMS.Application.Categories.Commands.DeleteCategory;
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
    public class DeleteCategoryCommandTests : CommandTestBase
    {
        private readonly DeleteCategoryCommandHandler _handler;

        public DeleteCategoryCommandTests() : base()
        {
            _handler = new DeleteCategoryCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidIdAndEmptyCategory_DeletesCategory()
        {
            var validId = 2;

            var command = new DeleteCategoryCommand() { Id = validId };

            await _handler.Handle(command, CancellationToken.None);

            var category = await _context.Categories.FindAsync(validId);

            category.ShouldBe(null);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 10;

            var command = new DeleteCategoryCommand() { Id = invalidId };

            await ShouldThrowAsyncExtensions.ShouldThrowAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidIdAndCategoryNotEmpty_ThrowsDeleteFailureException()
        {
            var validId = 1;

            var command = new DeleteCategoryCommand() { Id = validId };

            await ShouldThrowAsyncExtensions.ShouldThrowAsync<DeleteFailureException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}

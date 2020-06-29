using Shouldly;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.Contents.Commands.DeleteContent;
using SimpleCMS.Application.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimpleCMS.Application.UnitTests.Contents.Commands
{
    public class DeleteContentCommandTests : CommandTestBase
    {
        private readonly DeleteContentCommandHandler _handler;

        public DeleteContentCommandTests()
        {
            _handler = new DeleteContentCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidId_DeletesContent()
        {
            int validId = 1;

            var command = new DeleteContentCommand() { Id = validId };

            await _handler.Handle(command, CancellationToken.None);

            var content = await _context.Contents.FindAsync(validId);

            content.ShouldBe(null);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            int invalidId = 10;

            var command = new DeleteContentCommand() { Id = invalidId };

            await ShouldThrowAsyncExtensions.ShouldThrowAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}

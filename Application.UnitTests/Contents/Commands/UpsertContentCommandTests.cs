using Shouldly;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.Contents.Commands.UpsertContent;
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
    public class UpsertContentCommandTests : CommandTestBase
    {
        private readonly UpsertContentCommandHandler _handler;
        private readonly int validTopicId;

        public UpsertContentCommandTests()
        {
            _handler = new UpsertContentCommandHandler(_context);
            validTopicId = 1;
        }

        [Fact]
        public async Task Handle_GivenIdAndExists_UpdatesContent()
        {
            var id = 1;
            var newDescription = "An updated content description.";

            var command = new UpsertContentCommand() { Id = id, Name = "Content One", Description = newDescription, TopicId = validTopicId };
            await _handler.Handle(command, CancellationToken.None);

            var content = await _context.Contents.FindAsync(id);
            content.Description.ShouldBe(newDescription);
        }

        [Fact]
        public async Task Handle_GivenIdAndDoesntExist_ThrowsNotFoundException()
        {
            var id = 10;

            var command = new UpsertContentCommand() { Id = id, TopicId = validTopicId };

            await ShouldThrowAsyncExtensions.ShouldThrowAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenInvalidTopicId_ThrowsBadRequestException()
        {
            var command = new UpsertContentCommand() { TopicId = 10 };

            await ShouldThrowAsyncExtensions.ShouldThrowAsync<BadRequestException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_NotGivenId_CreatesContent()
        {
            var contentName = "New Content";
            var contentDescription = "New content description";

            var command = new UpsertContentCommand() { Name = contentName, Description = contentDescription, TopicId = validTopicId };
            await _handler.Handle(command, CancellationToken.None);

            var content = await _context.Contents.FindAsync(2);
            content.ShouldNotBe(null);
        }
    }
}

using SimpleCMS.Application.Topics.Commands.UpsertTopic;
using SimpleCMS.Application.UnitTests.Common;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Shouldly;
using SimpleCMS.Application.Common.Exceptions;

namespace SimpleCMS.Application.UnitTests.Topics.Commands
{
    public class UpsertTopicCommandTests : CommandTestBase
    {
        private UpsertTopicCommandHandler _handler;

        public UpsertTopicCommandTests()
        {
            _handler = new UpsertTopicCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenIdAndExists_UpdatesTopic()
        {
            var id = 1;
            var newDescription = "A brand new topic description";

            var command = new UpsertTopicCommand() { Id = id, CategoryId = 1, Description = newDescription, Name = "Non-empty Topic" };
            await _handler.Handle(command, CancellationToken.None);

            var topic = await _context.Topics.FindAsync(id);
            topic.Description.ShouldBe(newDescription);
        }

        [Fact]
        public async Task Handle_GivenIdAndDoesntExist_ThrowsNotFoundException()
        {
            var id = 10;

            var command = new UpsertTopicCommand() { Id = id, CategoryId = 1 };

            await ShouldThrowAsyncExtensions.ShouldThrowAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenInvalidCategoryId_ThrowsBadRequestException()
        {
            var command = new UpsertTopicCommand() { CategoryId = 10 };

            await ShouldThrowAsyncExtensions.ShouldThrowAsync<BadRequestException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_NotGivenId_CreatesTopic()
        {
            var topicName = "New Topic";
            var topicDescription = "Nice new topic description";

            var command = new UpsertTopicCommand() { Name = topicName, Description = topicDescription, CategoryId = 1 };
            await _handler.Handle(command, CancellationToken.None);

            var topic = await _context.Topics.FindAsync(3);
            topic.ShouldNotBe(null);
        }
    }
}

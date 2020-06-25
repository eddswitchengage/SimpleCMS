using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Application.Topics.Commands.DeleteTopic;
using SimpleCMS.Application.Topics.Commands.UpsertTopic;
using SimpleCMS.Application.Topics.Queries.GetTopicDetail;
using SimpleCMS.Application.Topics.Queries.GetTopicsList;
using System.Threading.Tasks;

namespace SimpleCMS.EditorClient.Controllers
{
    public class TopicsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetTopicsListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTopicDetailQuery() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Upsert([FromBody] UpsertTopicCommand command)
        {
            int topicId = await Mediator.Send(command);
            return Ok(topicId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTopicCommand { Id = id });
            return NoContent();
        }
    }
}

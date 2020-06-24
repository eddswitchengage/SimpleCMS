using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Application.Topics.Commands.DeleteTopic;
using SimpleCMS.Application.Topics.Commands.UpsertTopic;
using System.Threading.Tasks;

namespace SimpleCMS.EditorClient.Controllers
{
    public class TopicsController : BaseController
    {
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

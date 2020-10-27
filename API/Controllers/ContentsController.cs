using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Application.Contents.Commands.DeleteContent;
using SimpleCMS.Application.Contents.Commands.UpsertContent;
using SimpleCMS.Application.Contents.Queries.GetContentDetail;
using SimpleCMS.Application.Contents.Queries.GetContentsList;
using System;
using System.Threading.Tasks;

namespace SimpleCMS.API.Controllers
{
    public class ContentsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string searchTerm, [FromQuery] int topicId, [FromQuery] int categoryId,
            [FromQuery] DateTime? createdAfter, [FromQuery] DateTime? modifiedAfter,
            [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await Mediator.Send(new GetContentsListQuery()
            {
                SearchTerm = searchTerm,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TopicId = topicId,
                CategoryId = categoryId,
                CreatedAfter = createdAfter,
                ModifiedAfter = modifiedAfter
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetContentDetailQuery() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Upsert([FromBody] UpsertContentCommand command)
        {
            int contentId = await Mediator.Send(command);

            return Ok(contentId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteContentCommand() { Id = id });
            return NoContent();
        }
    }
}

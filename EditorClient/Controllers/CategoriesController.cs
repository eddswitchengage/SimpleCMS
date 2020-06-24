using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Application.Categories.Commands.DeleteCategory;
using SimpleCMS.Application.Categories.Commands.UpsertCategory;
using SimpleCMS.Application.Categories.Queries.GetCategoriesList;
using System.Threading.Tasks;

namespace SimpleCMS.EditorClient.Controllers
{
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetCategoriesListQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Upsert([FromBody] UpsertCategoryCommand command)
        {
            int categoryId = await Mediator.Send(command);
            return Ok(categoryId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }
    }
}

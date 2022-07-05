using Books.Api.Queries.Categories;
using Books.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Categories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var query = new GetAllCategoriesQuery();
            var result = _mediator.Send(query);

            return Ok(result.Result);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        public ActionResult<CategoryDto> GetCategory(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = _mediator.Send(query);
            return Ok(result.Result);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryCreateDto categoryCreateDto)
        {
            var query = new UpdateCategoryQuery(id, categoryCreateDto);
            await _mediator.Send(query);

            return NoContent();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryCreateDto categoryCreateDto)
        {
            var query = new CreateCategoryQuery(categoryCreateDto);
            var result = await _mediator.Send(query);

            return CreatedAtAction(nameof(GetCategory), new { id = result.Id }, result);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var query = new DeleteCategoryQuery(id);
            await _mediator.Send(query);

            return NoContent();
        }
    }
}

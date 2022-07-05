using Books.Api.Queries.Books;
using Books.Contracts;
using Books.Contracts.ApiRoutes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Books
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            var query = new GetAllBooksQuery();
            var result = _mediator.Send(query);
            
            return Ok(result.Result);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public ActionResult<BookDto> GetBook(int id)
        {
            var query = new GetBookByIdQuery(id);
            var result = _mediator.Send(query);
            return Ok(result.Result);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookCreateDto bookCreateDto)
        {
            var query =new UpdateBookQuery(id, bookCreateDto);
            await _mediator.Send(query);

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(BookCreateDto bookCreateDto)
        {
            var query = new CreateBookQuery(bookCreateDto);
            var result = await _mediator.Send(query);

            return CreatedAtAction(nameof(GetBook), new { id = result.Id }, result);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var query = new DeleteBookQuery(id);
            await _mediator.Send(query);

            return NoContent();
        }
    }
}
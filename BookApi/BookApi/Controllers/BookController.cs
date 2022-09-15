using BookApi.Model;
using BookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepositorie _bookRepositorie;
        public BookController(IBookRepositorie bookRepositorie)
        {
            _bookRepositorie = bookRepositorie;
        }

        [HttpGet]

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepositorie.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepositorie.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepositorie.Create(book);
            return book;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookDelete = await _bookRepositorie.Get(id);
            if (bookDelete == null)
            {
                return NotFound();
                
            }
            await _bookRepositorie.Delete(bookDelete.ID);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.ID)
            {
                return NotFound();
                
                
            }
            await _bookRepositorie.Update(book);
            return NoContent();

        }
    } 
}

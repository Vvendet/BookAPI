using BookApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories
{
    public class BookRepositorie : IBookRepositorie
    {
        public readonly BookContext _context;

        public BookRepositorie(BookContext context)
        {
            _context = context;

        }
        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int ID)
        {
            var bookDelete = await _context.Books.FindAsync(ID);
            _context.Books.Remove(bookDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int ID)
        {
            return await _context.Books.FindAsync(ID);
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

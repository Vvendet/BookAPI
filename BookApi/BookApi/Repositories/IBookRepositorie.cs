using BookApi.Model;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace BookApi.Repositories
{
    public interface IBookRepositorie
    {
        Task<IEnumerable<Book>> Get();

        Task<Book> Get(int ID);

        Task<Book> Create(Book book);
        Task Update(Book book);
        Task Delete(int ID);

    }
}

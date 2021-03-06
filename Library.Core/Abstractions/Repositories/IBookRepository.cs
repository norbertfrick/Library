using Library.Core.Entities;

namespace Library.Core.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    {
        bool IsBookAvailable(int id);
    }
}

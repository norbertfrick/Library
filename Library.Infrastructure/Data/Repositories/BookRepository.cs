using Library.Core.Abstractions;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;

        public Book Create(Book entity)
        {
            throw new NotImplementedException();
        }

        public Book Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Book entity)
        {
            throw new NotImplementedException();
        }
    }
}

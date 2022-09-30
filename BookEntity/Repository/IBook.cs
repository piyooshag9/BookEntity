using BookEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEntity.Repository
{
    public interface IBook
    {
        public List<Book> GetBooks();

        public Book GetBook(Guid id);

        public Book CreateBook(BookCreate book);

        public Book UpdateBook(Guid id, BookCreate book);
    }
}

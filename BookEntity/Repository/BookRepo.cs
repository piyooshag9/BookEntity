using BookEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEntity.Repository
{
    public class BookRepo : IBook
    {
        BookContext _bookContext;
        public BookRepo(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public Book CreateBook(BookCreate book)
        {
            Book b = new Book { Id = Guid.NewGuid() };
            b.Name = book.Name;
            b.AuthorName = book.AuthorName;
            _bookContext.Add(b);
            _bookContext.SaveChanges();
            return b;
        }

        public Book GetBook(Guid id)
        {
            return _bookContext.Books.SingleOrDefault(x => x.Id == id);
        }

        public List<Book> GetBooks()
        {
           return _bookContext.Books.ToList();
        }

        public Book UpdateBook(Guid id, BookCreate book)
        {
            var bookCheck = _bookContext.Books.Find(id);
          
            if (bookCheck != null)
            {
                bookCheck.Name = book.Name;
                bookCheck.AuthorName = book.AuthorName;
                _bookContext.Update(bookCheck);
                _bookContext.SaveChanges();
            }
            return bookCheck;
        }
    }
}

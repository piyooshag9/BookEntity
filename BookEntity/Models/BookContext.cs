using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEntity.Models
{
    public class BookContext: DbContext
    {
        public BookContext(DbContextOptions<BookContext> Options):base(Options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}

using LibraryMananementDemo.Entities;
using LibraryMananementDemo.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMananementDemo.Repositories
{
    public interface IBookRepository
    {
        Book AddBook(BookInputType book);
        Book UpdateBook(BookInputType book);
        Book DeleteBook(BookInputType book);
        IQueryable<Book> GetBooks();
    }
}

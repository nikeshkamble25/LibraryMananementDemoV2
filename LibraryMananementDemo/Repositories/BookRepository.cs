using LibraryMananementDemo.Entities;
using LibraryMananementDemo.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMananementDemo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryGraphQLDemoContext _context;

        public BookRepository(LibraryGraphQLDemoContext context)
        {
            _context = context;
        }
        public Book AddBook(BookInputType book)
        {
            var bk = new Book()
            {
                AuthorId = book.AuthorId,
                Title = book.Title,
                Price = book.Price
            };
            _context.Book.Add(bk);
            _context.SaveChanges();
            return bk;
        }

        public Book DeleteBook(BookInputType book)
        {
            var bk = _context.Book.Where(b => b.Id == book.Id).FirstOrDefault();
            _context.Book.Remove(bk);
            _context.SaveChanges();
            return bk;
        }

        public IQueryable<Book> GetBooks() => _context.Book.AsQueryable();

        public Book UpdateBook(BookInputType book)
        {
            var bk = _context.Book.Where(b => b.Id == book.Id).FirstOrDefault();
            bk.Price = book.Price;
            bk.Title = book.Title;
            bk.AuthorId = book.AuthorId;
            _context.Book.Update(bk);
            _context.SaveChanges();
            return bk;
        }
    }
}

using LibraryMananementDemo.Entities;
using LibraryMananementDemo.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMananementDemo.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryGraphQLDemoContext _context;

        public AuthorRepository(LibraryGraphQLDemoContext context)
        {
            _context = context;
        }
        public Author AddAuthor(AuthorInputType author)
        {
            var bk = new Author()
            {
                 Id = author.Id,
                 Name = author.Name,
                 Surname = author.Surname
            };
            _context.Author.Add(bk);
            _context.SaveChanges();
            return bk;
        }

        public Author DeleteAuthor(AuthorInputType author)
        {
            var bk = _context.Author.Where(b => b.Id == b.Id).FirstOrDefault();
            _context.Author.Remove(bk);
            _context.SaveChanges();
            return bk;
        }

        public IQueryable<Author> GetAuthor() => _context.Author.AsQueryable();

        public Author UpdateAuthor(AuthorInputType author)
        {
            var bk = _context.Author.Where(b => b.Id == b.Id).FirstOrDefault();
            bk.Name = author.Name;
            bk.Surname = author.Surname;
            _context.Author.Update(bk);
            _context.SaveChanges();
            return bk;
        }
    }
}

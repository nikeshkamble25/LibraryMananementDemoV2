using LibraryMananementDemo.Entities;
using LibraryMananementDemo.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMananementDemo.Repositories
{
    public interface IAuthorRepository
    {
        Author AddAuthor(AuthorInputType author);
        Author UpdateAuthor(AuthorInputType author);
        Author DeleteAuthor(AuthorInputType author);
        IQueryable<Author> GetAuthor();
    }
}

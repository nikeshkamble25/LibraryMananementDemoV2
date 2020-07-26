using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using LibraryMananementDemo.Entities;
using LibraryMananementDemo.GraphQLTypes;
using LibraryMananementDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMananementDemo.GraphQLServices
{
    public class LibraryQuery
    {
        
        [UsePaging(SchemaType = typeof(BookType))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> Books([Service] IBookRepository bookRepository) => bookRepository.GetBooks();

        [UsePaging(SchemaType = typeof(AuthorType))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> Authors([Service] IAuthorRepository authorRepository) => authorRepository.GetAuthor();

    }
}

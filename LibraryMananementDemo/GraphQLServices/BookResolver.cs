using HotChocolate;
using HotChocolate.Resolvers;
using LibraryMananementDemo.Entities;
using LibraryMananementDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMananementDemo.GraphQLServices
{
    public class BookResolver
    {
        private readonly IBookRepository _repository;
        public BookResolver([Service]IBookRepository repository)
        {
            this._repository = repository;
        }
        public List<Book> GetBooks(Author author, IResolverContext ctx)
        {
            return _repository.GetBooks().Where(x => x.AuthorId == author.Id).ToList();
        }
    }
}

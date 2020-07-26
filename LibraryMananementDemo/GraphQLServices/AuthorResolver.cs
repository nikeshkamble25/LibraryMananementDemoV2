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
    public class AuthorResolver
    {
        private readonly IAuthorRepository _repository;
        public AuthorResolver([Service]IAuthorRepository repository)
        {
            this._repository = repository;
        }
        public Author GetAuthor(Book book, IResolverContext ctx)
        {
            return _repository.GetAuthor().Where(x => x.Id == book.AuthorId).FirstOrDefault();
        }
    }
}

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
    public class LibraryMutation
    {
        public Book AddBooks([Service] IBookRepository bookRepository, BookInputType bookInputType)
        {
          return  bookRepository.AddBook(bookInputType);
        }
        public Book UpdateBooks([Service] IBookRepository bookRepository, BookInputType bookInputType)
        {
            return bookRepository.UpdateBook(bookInputType);
        }
        public bool DeleteBooks([Service] IBookRepository bookRepository, BookInputType bookInputType)
        {
            bookRepository.DeleteBook(bookInputType);
            return true;
        }
    }
}

using HotChocolate.Types;
using LibraryMananementDemo.Entities;

namespace LibraryMananementDemo.GraphQLTypes
{
    public class AuthorInputType
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Surname { get; set; }
    }
}

using HotChocolate.Types;
using LibraryMananementDemo.Entities;

namespace LibraryMananementDemo.GraphQLTypes
{
    public class BookInputType
    {
        public int? Id { get; set; }
        public int? AuthorId { get; set; }
        public string Title{ get; set; }
        public decimal? Price { get; set; }
    }
}

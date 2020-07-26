using HotChocolate.Types;
using LibraryMananementDemo.Entities;
using LibraryMananementDemo.GraphQLServices;

namespace LibraryMananementDemo.GraphQLTypes
{
    public class BookType: ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Name("Books");
            descriptor.Field(x => x.Id).Type<IdType>();
            descriptor.Field(x => x.Title).Type<StringType>();
            descriptor.Field(x => x.Price).Type<DecimalType>();
            descriptor.Field<AuthorResolver>(x => x.GetAuthor(default, default));
        }
    }
}
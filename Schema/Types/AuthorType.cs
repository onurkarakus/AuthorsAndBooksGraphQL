using AuthorsAndBooksGraphQL.Abstractions.Services;
using AuthorsAndBooksGraphQL.Models;
using GraphQL.Types;

namespace AuthorsAndBooksGraphQL.Schema.Types;

/// <summary>
/// Represents an author in the system.
/// </summary>
public class AuthorType : ObjectGraphType<Author>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorType"/> class.
    /// </summary>
    /// <param name="bookService">The book service.</param>
    public AuthorType(IBookService bookService)
    {
        Field(x => x.Id).Description("Yazar Kayıt No");
        Field(x => x.Name).Description("Yazar Adı");
        Field(x => x.LastName).Description("Yazar Soyadı");
        Field(x => x.Books, type: typeof(ListGraphType<BookType>))
            .Description("Yazarın Kitapları")
            .ResolveAsync(async context => await bookService.GetAllBooksByAuthorAsync(context.Source.Id));
    }
}

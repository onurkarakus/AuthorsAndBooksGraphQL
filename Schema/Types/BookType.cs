using AuthorsAndBooksGraphQL.Abstractions.Services;
using AuthorsAndBooksGraphQL.Models;
using GraphQL.Types;

namespace AuthorsAndBooksGraphQL.Schema.Types;

/// <summary>
/// Represents a book type.
/// </summary>
public class BookType : ObjectGraphType<Book>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BookType"/> class.
    /// </summary>
    /// <param name="authorService">The author service.</param>
    public BookType(IAuthorService authorService)
    {
        Field(x => x.Id).Description("Kitap Kayıt No");
        Field(x => x.Title).Description("Kitap Başlık");
        Field(x => x.AuthorId).Description("Yazar Kayıt No");
        Field<AuthorType>("author")
            .Description("Yazar")
            .ResolveAsync(async context => await authorService.GetAuthorByIdAsync(context.Source.AuthorId));
    }
}

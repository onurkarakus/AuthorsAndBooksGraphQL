using AuthorsAndBooksGraphQL.Abstractions.Services;
using AuthorsAndBooksGraphQL.Schema.Types;
using GraphQL;
using GraphQL.Types;

namespace AuthorsAndBooksGraphQL.Schema.Queries;

/// <summary>
/// Represents the query class for the AuthorsAndBooksGraphQL schema.
/// </summary>
public class Query : ObjectGraphType<object>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Query"/> class.
    /// </summary>
    /// <param name="authorService">The author service.</param>
    /// <param name="bookService">The book service.</param>
    public Query(IAuthorService authorService, IBookService bookService)
    {
        Name = "AuthorsAndBooksQuery";

        Field<ListGraphType<AuthorType>>("authors").ResolveAsync(async context => await authorService.GetAllAuthorsAsync());

        Field<AuthorType>("author").Arguments(
            new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }))
            .ResolveAsync(async context => await authorService.GetAuthorByIdAsync(context.GetArgument<int>("id")));

        Field<ListGraphType<BookType>>("books").ResolveAsync(async context => await bookService.GetAllBooksAsync());

        Field<AuthorType>("book").Arguments(
            new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }))
            .ResolveAsync(async context => await bookService.GetBookByIdAsync(context.GetArgument<int>("id")));
    }
}

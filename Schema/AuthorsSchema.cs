using AuthorsAndBooksGraphQL.Schema.Queries;
using GraphQL.Types;

namespace AuthorsAndBooksGraphQL.Schema;

/// <summary>
/// Represents the schema for authors and books in the GraphQL API.
/// </summary>
public class AuthorsSchema : GraphQL.Types.Schema
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorsSchema"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public AuthorsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Description = "Author And Book Schema";
        Query = serviceProvider.GetRequiredService<Query>();
    }
}

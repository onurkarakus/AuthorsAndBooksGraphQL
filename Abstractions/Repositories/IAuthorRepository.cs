using AuthorsAndBooksGraphQL.Models;

namespace AuthorsAndBooksGraphQL.Abstractions.Repositories;

/// <summary>
/// Represents the interface for the author repository.
/// </summary>
/// <typeparam name="Author">The type of the author.</typeparam>
public interface IAuthorRepository : IGenericRepository<Author>
{

}

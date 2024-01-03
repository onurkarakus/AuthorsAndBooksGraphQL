using AuthorsAndBooksGraphQL.Models;

namespace AuthorsAndBooksGraphQL.Abstractions.Repositories;

/// <summary>
/// Represents a repository for managing books.
/// </summary>
public interface IBookRepository : IGenericRepository<Book>
{

}

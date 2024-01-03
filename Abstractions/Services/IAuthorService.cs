using AuthorsAndBooksGraphQL.Models;

namespace AuthorsAndBooksGraphQL.Abstractions.Services;

/// <summary>
/// Represents the interface for the author service.
/// </summary>
public interface IAuthorService
{
    /// <summary>
    /// Retrieves all authors asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of authors.</returns>
    Task<List<Author>> GetAllAuthorsAsync();

    /// <summary>
    /// Retrieves an author by their ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the author.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the author.</returns>
    Task<Author> GetAuthorByIdAsync(int id);

    /// <summary>
    /// Adds a new author asynchronously.
    /// </summary>
    /// <param name="entity">The author entity to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added author.</returns>
    Task<Author> AddAuthorAsync(Author entity);
}

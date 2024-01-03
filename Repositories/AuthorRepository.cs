using AuthorsAndBooksGraphQL.Abstractions.Repositories;
using AuthorsAndBooksGraphQL.Models;

namespace AuthorsAndBooksGraphQL.Repositories;

/// <summary>
/// Represents a repository for managing authors.
/// </summary>
public class AuthorRepository : IAuthorRepository
{
    private List<Author> _authors;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorRepository"/> class.
    /// </summary>
    public AuthorRepository()
    {
        _authors = new List<Author>
                        {
                            new() {
                                Id = 1,
                                Name = "Stephen Edwin",
                                LastName = "King"
                            },
                            new() {
                                Id = 1,
                                Name = "John Ronald Reuel",
                                LastName = "Tolkien"
                            },
                        };
    }

    /// <summary>
    /// Adds a new author asynchronously.
    /// </summary>
    /// <param name="entity">The author entity to add.</param>
    /// <returns>The added author.</returns>
    public Task<Author> AddAsync(Author entity)
    {
        entity.Id = _authors.Count + 1;
        _authors.Add(entity);

        return Task.FromResult(entity);
    }

    /// <summary>
    /// Gets all authors asynchronously.
    /// </summary>
    /// <returns>A list of authors.</returns>
    public Task<List<Author>> GetAllAsync()
    {
        return Task.FromResult(_authors);
    }

    /// <summary>
    /// Gets an author by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the author to retrieve.</param>
    /// <returns>The author with the specified ID.</returns>
    public Task<Author> GetByIdAsync(int id)
    {
        return Task.FromResult(_authors.Find(a => a.Id == id));
    }
}

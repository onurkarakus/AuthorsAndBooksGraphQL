using AuthorsAndBooksGraphQL.Abstractions.Repositories;
using AuthorsAndBooksGraphQL.Abstractions.Services;
using AuthorsAndBooksGraphQL.Models;

namespace AuthorsAndBooksGraphQL.Services;

/// <summary>
/// Represents a service for managing authors.
/// </summary>
public class AuthorService : IAuthorService
{
    readonly IBookService bookService;
    readonly IAuthorRepository authorRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorService"/> class.
    /// </summary>
    /// <param name="authorRespository">The author repository.</param>
    /// <param name="bookService">The book service.</param>
    public AuthorService(IAuthorRepository authorRespository, IBookService bookService)
    {
        this.authorRepository = authorRespository;
        this.bookService = bookService;
    }

    /// <summary>
    /// Adds a new author asynchronously.
    /// </summary>
    /// <param name="entity">The author entity.</param>
    /// <returns>The added author.</returns>
    public async Task<Author> AddAuthorAsync(Author entity)
    {
        return await authorRepository.AddAsync(entity);
    }

    /// <summary>
    /// Gets all authors asynchronously.
    /// </summary>
    /// <returns>A list of authors.</returns>
    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        var authors = await authorRepository.GetAllAsync();

        foreach (var author in authors)
        {
            author.Books = await bookService.GetAllBooksByAuthorAsync(author.Id);
        }

        return authors;
    }

    /// <summary>
    /// Gets an author by ID asynchronously.
    /// </summary>
    /// <param name="id">The author ID.</param>
    /// <returns>The author with the specified ID.</returns>
    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        var author = await authorRepository.GetByIdAsync(id);

        if (author != null)
        {
            author.Books = await bookService.GetAllBooksByAuthorAsync(author.Id);
        }

        return author;
    }
}

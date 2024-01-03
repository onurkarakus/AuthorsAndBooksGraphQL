using AuthorsAndBooksGraphQL.Models;

namespace AuthorsAndBooksGraphQL.Abstractions.Services;

/// <summary>
/// Represents a service for managing books.
/// </summary>
public interface IBookService
{
    /// <summary>
    /// Adds a new book to the database.
    /// </summary>
    /// <param name="entity">The book entity to add.</param>
    /// <returns>The added book.</returns>
    Task<Book> AddBookAsync(Book entity);

    /// <summary>
    /// Retrieves all books from the database.
    /// </summary>
    /// <returns>A list of all books.</returns>
    Task<List<Book>> GetAllBooksAsync();

    /// <summary>
    /// Retrieves all books written by a specific author.
    /// </summary>
    /// <param name="authorId">The ID of the author.</param>
    /// <returns>A list of books written by the author.</returns>
    Task<List<Book>> GetAllBooksByAuthorAsync(int authorId);

    /// <summary>
    /// Retrieves a book by its ID.
    /// </summary>
    /// <param name="id">The ID of the book.</param>
    /// <returns>The book with the specified ID.</returns>
    Task<Book> GetBookByIdAsync(int id);
}

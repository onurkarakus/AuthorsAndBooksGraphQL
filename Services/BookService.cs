using AuthorsAndBooksGraphQL.Abstractions.Repositories;
using AuthorsAndBooksGraphQL.Abstractions.Services;
using AuthorsAndBooksGraphQL.Models;

namespace AuthorsAndBooksGraphQL.Services;

/// <summary>
/// Represents a service for managing books.
/// </summary>
public class BookService : IBookService
{
    readonly IBookRepository bookRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookService"/> class.
    /// </summary>
    /// <param name="bookRepository">The book repository.</param>
    public BookService(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    /// <summary>
    /// Adds a new book asynchronously.
    /// </summary>
    /// <param name="entity">The book entity to add.</param>
    /// <returns>The added book.</returns>
    public async Task<Book> AddBookAsync(Book entity)
    {
        return await bookRepository.AddAsync(entity);
    }

    /// <summary>
    /// Gets all books asynchronously.
    /// </summary>
    /// <returns>A list of all books.</returns>
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await bookRepository.GetAllAsync();
    }

    /// <summary>
    /// Gets all books by author asynchronously.
    /// </summary>
    /// <param name="authorId">The author ID.</param>
    /// <returns>A list of books by the specified author.</returns>
    public async Task<List<Book>> GetAllBooksByAuthorAsync(int authorId)
    {
        return (await bookRepository.GetAllAsync()).Where(p => p.AuthorId == authorId).ToList();
    }

    /// <summary>
    /// Gets a book by ID asynchronously.
    /// </summary>
    /// <param name="id">The book ID.</param>
    /// <returns>The book with the specified ID.</returns>
    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await bookRepository.GetByIdAsync(id);
    }
}

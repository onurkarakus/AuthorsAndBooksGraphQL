using AuthorsAndBooksGraphQL.Abstractions.Repositories;
using AuthorsAndBooksGraphQL.Models;

namespace AuthorsAndBooksGraphQL.Repositories;

/// <summary>
/// Represents a repository for managing books.
/// </summary>
public class BookRepository : IBookRepository
{
    private List<Book> _books;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookRepository"/> class.
    /// </summary>
    public BookRepository()
    {
        _books = new List<Book>
        {
            new() { Id = 1, Title = "The Shining (Medyum)", AuthorId = 1 },
            new() { Id = 2, Title = "Doctor Sleep (Doktor Uyku)", AuthorId = 1 },
            new() { Id = 3, Title = "Hobbit", AuthorId = 2 },
            new() { Id = 4, Title = "Lord Of The Rings (Yüzüklerin Efendisi)", AuthorId = 2 }
        };
    }

    /// <summary>
    /// Adds a new book asynchronously.
    /// </summary>
    /// <param name="entity">The book entity to add.</param>
    /// <returns>The added book entity.</returns>
    public Task<Book> AddAsync(Book entity)
    {
        entity.Id = _books.Count + 1;
        _books.Add(entity);

        return Task.FromResult(entity);
    }

    /// <summary>
    /// Gets all books asynchronously.
    /// </summary>
    /// <returns>A list of all books.</returns>
    public Task<List<Book>> GetAllAsync()
    {
        return Task.FromResult(_books);
    }

    /// <summary>
    /// Gets a book by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the book to retrieve.</param>
    /// <returns>The book with the specified ID.</returns>
    public Task<Book> GetByIdAsync(int id)
    {
        return Task.FromResult(_books.Find(a => a.Id == id));
    }
}

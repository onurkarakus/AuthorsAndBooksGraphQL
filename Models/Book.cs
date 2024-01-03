namespace AuthorsAndBooksGraphQL.Models;

/// <summary>
/// Represents a book.
/// </summary>
public class Book
{
    /// <summary>
    /// Gets or sets the ID of the book.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the ID of the author of the book.
    /// </summary>
    public int AuthorId { get; set; }
}

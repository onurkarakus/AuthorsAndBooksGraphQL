namespace AuthorsAndBooksGraphQL.Models;

/// <summary>
/// Represents an author.
/// </summary>
public class Author
{
    /// <summary>
    /// Gets or sets the ID of the author.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the author.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the last name of the author.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the list of books written by the author.
    /// </summary>
    public List<Book> Books { get; set; }
}

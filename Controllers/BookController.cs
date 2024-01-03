using AuthorsAndBooksGraphQL.Abstractions.Services;
using AuthorsAndBooksGraphQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsAndBooksGraphQL.Controllers;

/// <summary>
/// Represents a controller for managing books.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    readonly IBookService _bookService;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookController"/> class.
    /// </summary>
    /// <param name="bookService">The book service.</param>
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Gets all books asynchronously.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> representing the asynchronous operation.</returns>
    [HttpGet("all-books")]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        return Ok(await _bookService.GetAllBooksAsync());
    }

    /// <summary>
    /// Gets a book by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the book.</param>
    /// <returns>An <see cref="IActionResult"/> representing the asynchronous operation.</returns>
    [HttpGet("book-by-id/{id}")]
    public async Task<IActionResult> GetBookByIdAsync(int id)
    {
        return Ok(await _bookService.GetBookByIdAsync(id));
    }

    /// <summary>
    /// Adds a book asynchronously.
    /// </summary>
    /// <param name="bookDto">The book to add.</param>
    /// <returns>An <see cref="IActionResult"/> representing the asynchronous operation.</returns>
    [HttpPost("add-book")]
    public async Task<IActionResult> AddBookAsync(Book bookDto)
    {
        return Ok(await _bookService.AddBookAsync(bookDto));
    }
}

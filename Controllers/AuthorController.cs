using AuthorsAndBooksGraphQL.Abstractions.Services;
using AuthorsAndBooksGraphQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsAndBooksGraphQL.Controllers;

/// <summary>
/// Represents a controller for managing authors.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    readonly IAuthorService _authorService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorController"/> class.
    /// </summary>
    /// <param name="authorService">The author service.</param>
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    /// <summary>
    /// Gets all authors.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> representing the response of the action.</returns>
    [HttpGet("all-authors")]
    public async Task<IActionResult> GetAllAuthorsAsync()
    {
        return Ok(await _authorService.GetAllAuthorsAsync());
    }

    /// <summary>
    /// Gets an author by ID.
    /// </summary>
    /// <param name="id">The ID of the author.</param>
    /// <returns>An <see cref="IActionResult"/> representing the response of the action.</returns>
    [HttpGet("author-by-id/{id}")]
    public async Task<IActionResult> GetAuthorByIdAsync(int id)
    {
        return Ok(await _authorService.GetAuthorByIdAsync(id));
    }

    /// <summary>
    /// Adds a new author.
    /// </summary>
    /// <param name="authorDto">The author DTO.</param>
    /// <returns>An <see cref="IActionResult"/> representing the response of the action.</returns>
    [HttpPost("add-author")]
    public async Task<IActionResult> AddAuthorAsync(Author authorDto)
    {
        return Ok(await _authorService.AddAuthorAsync(authorDto));
    }
}

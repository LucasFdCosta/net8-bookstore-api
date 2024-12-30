using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookstore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpGet("{id:int:min(1)}", Name = "GetById")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var book = new Book()
        {
            Id = 1,
            Author = "Lucas",
            Genre = BookGenre.Mystery,
            Quantity = 10,
            Title = "A Really mysterious book",
            Price = 10.5
        };

        if (id == 1) return Ok(book);

        return NotFound("No book was found with this ID!");
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Author = "Lucas",
                Genre = BookGenre.Mystery,
                Quantity = 10,
                Title = "A Really mysterious book",
                Price = 10.5
            },
            new Book
            {
                Id = 2,
                Author = "John Doe",
                Genre = BookGenre.Philosophy,
                Quantity = 7,
                Title = "What should I do?",
                Price = 15.5
            },
            new Book
            {
                Id = 3,
                Author = "Bob",
                Genre = BookGenre.Fiction,
                Quantity = 5,
                Title = "Bob's adventure",
                Price = 20
            },
            new Book
            {
                Id = 4,
                Author = "Alice",
                Genre = BookGenre.Romance,
                Quantity = 6,
                Title = "A Really romantic book",
                Price = 25.9
            },
        };

        return Ok(books);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public IActionResult Post([FromBody] Book book)
    {
        return Created(string.Empty, book);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Put([FromRoute] int id, [FromBody] Book book)
    {
        if (id == 1) return Ok(book);

        return NotFound("No book was found with this ID!");
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Book), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        if (id == 1) return NoContent();

        return NotFound("No book was found with this ID!");
    }
}

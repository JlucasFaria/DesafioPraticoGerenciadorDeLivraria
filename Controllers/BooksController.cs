using DesafioPraticoGerenciadorDeLivraria.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPraticoGerenciadorDeLivraria.Controllers;
[Route("api/[controller]")]
[ApiController]

public class BooksController : ControllerBase
{
    public static List<RequestRegisterBook> books = new List<RequestRegisterBook>();
    private static int idCounter = 1;

    [HttpPost]
    public IActionResult BookCreate(RequestRegisterBook book)
    {
        book.Id = idCounter++;
        books.Add(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);

    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        var book = books.FirstOrDefault(l => l.Id == id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPut("{id}")]
    public IActionResult EditBook(int id, RequestRegisterBook updatedBook)
    {
        var book = books.FirstOrDefault(l => l.Id == id);
        if (book == null)
            return NotFound();

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.Genre = updatedBook.Genre;
        book.Price = updatedBook.Price;
        book.QuantityAvailable = updatedBook.QuantityAvailable;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id) 
    {
        var book = books.FirstOrDefault(l => l.Id == id);
        if (book == null)
            return NotFound();

        books.Remove(book);
        return NoContent();
    }
}

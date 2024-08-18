using Homework___Class_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework___Class_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetNotes()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDB.Books);
            }
            catch (Exception ex)
            {
                // log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured! Contact the admin!");
            }
        }

        [HttpGet("{index}")]
        public ActionResult<Book> GetBookByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index cannot be negative !");
                }
                if (index >= StaticDB.Books.Count)
                {
                    return NotFound($"There is no resource on index {index}");
                }

                return Ok(StaticDB.Books[index]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured! Contact the admin!");
            }
        }

        [HttpGet("filter")]
        public ActionResult<Book> GetBookByFilter([FromQuery] string author, [FromQuery] string title)
        {
            try
            {
                var book = StaticDB.Books.FirstOrDefault(b => b.Author == author && b.Title == title);
                if (book == null)
                {
                    return NotFound("Book not found with the specified author and title.");
                }
                return Ok(book);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book newBook)
        {
            try
            {
                if (newBook == null)
                {
                    return BadRequest("Book object is null.");
                }

                if (string.IsNullOrEmpty(newBook.Author) || string.IsNullOrEmpty(newBook.Title))
                {
                    return BadRequest("Both Author and Title must be provided.");
                }

                StaticDB.Books.Add(newBook);
                return Ok("Book added successfully.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add-multiple")]
        public ActionResult<List<string>> AddBooks([FromBody] List<Book> newBooks)
        {
            try
            {
                if (newBooks == null || newBooks.Count == 0)
                {
                    return BadRequest("No books were provided.");
                }

                var invalidBooks = newBooks.Where(b => string.IsNullOrEmpty(b.Author) || string.IsNullOrEmpty(b.Title)).ToList();

                if (invalidBooks.Count > 0)
                {
                    return BadRequest("All books must have both Author and Title.");
                }

                StaticDB.Books.AddRange(newBooks);
                var titles = newBooks.Select(b => b.Title).ToList();

                return Ok(titles);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

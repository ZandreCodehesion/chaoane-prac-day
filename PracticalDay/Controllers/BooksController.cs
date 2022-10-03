using Microsoft.AspNetCore.Mvc;
using PracticalDay.Database;
using PracticalDay.Model;

namespace PracticalDay.Controllers;


public class BooksController : ControllerBase
{
    private readonly IBooksDatabase book;

    public BooksController(IBooksDatabase _books)
    {
        book=_books;
       
    }
    [HttpPost]
    [Route("/Books")]
    public async Task<ActionResult<BooksModel>> Create(BooksModel booksModel)
    {
        return await book.Create(booksModel);
    }

    [HttpGet("{id}")]
    public async Task<BooksModel> Get(Guid id)
    {
        return await book.Get(id);
    }
    
    

}
using Microsoft.AspNetCore.Mvc;
using PracticalDay.Database;
using PracticalDay.Model;

namespace PracticalDay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksDatabase _book;

    public BooksController(IBooksDatabase books)
    {
        _book=books;
    }
    
    [HttpPost]
    [Route("/Books")]
    public async Task<ActionResult<BooksModel>> Create(BooksModel booksModel)
    {
        return await _book.Create(booksModel);
    }

    [HttpGet("{AuthorId}")]
    public async Task<BooksModel> Get(Guid id)
    {
        return await _book.Get(id);
    }
    
    [HttpGet("{authorsId}/{booksId}")]
    public async Task<BooksModel> Get(Guid authorsId,Guid booksId)
    {
        return await _book.Get(authorsId,booksId);
    }
    
    [HttpGet]
    public async Task<IEnumerable<BooksModel>> Get()
    {
        return await _book.Get();
    }
    
    
    
    
}